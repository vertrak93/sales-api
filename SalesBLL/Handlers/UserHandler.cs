using SalesBLL.Constants;
using SalesBLL.DTO;
using SalesBLL.Helpers;
using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesBLL.Handlers
{
    public class UserHandler
    {
        #region Constructor
        MyDbContext _context;
        public UserHandler(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Get Methods
        public List<User> Get()
        {
            return _context.User.ToList();
        }

        public User? Get(int id) 
        {
            return _context.User.Where(obj => obj.UserId == id ).FirstOrDefault();
        }
        #endregion

        #region Update-Insert Methods
        public void Post(User user) 
        {
            var objUser = user;

            ValidatePostUser(user);
            objUser.Password = Cryptography.GetSHA256(user.Password);
            _context.SetCreator<User>(user);

            _context.User.Add(objUser);
            _context.SaveChanges();
        }

        public void Patch(User user)
        {
            ValidateEmailFormat(user);
            var objUser = _context.User.Where(obj => obj.UserId == user.UserId).FirstOrDefault();
            if (objUser != null)
            {
                objUser.FisrtName = user.FisrtName;
                objUser.LastName = user.LastName;
                objUser.Email = user.Email;
                _context.SetModifier<User>(objUser);

                _context.SaveChanges();
            }
        }

        public void ChangePassword(User user)
        {
            ValidatePasswordFormat(user);
            ValidateExistingPassword(user);
            var objUser = _context.User.Where(obj => obj.UserId == user.UserId).FirstOrDefault();
            if (objUser != null)
            {
                var newPassword = Cryptography.GetSHA256(user.Password);
                objUser.Password = newPassword;
                _context.SetModifier<User>(objUser);

                _context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var objUser = _context.User.Where(obj => obj.UserId == id).FirstOrDefault();

            if (objUser != null)
            {
                _context.SetModifier<User>(objUser);
                objUser.Active = false;
                    
                _context.SaveChanges();
            }

        }
        #endregion

        #region Validations

        public void ValidatePostUser(User user) 
        { 
            ValidatePasswordFormat(user);
            ValidateEmailFormat(user);
            ValidateExistingUser(user);
            ValidateExistingEmail(user);
        }

        public void ValidateExistingUser(User user)
        {
            var objUser = _context.User.Where(obj => obj.Username.ToUpper() == user.Username).ToList();
            if (objUser.Count > 0) { throw new Exception(Messages.ExistingUserName); }
        }

        public void ValidateExistingEmail(User user)
        {
            var objMail = _context.User.Where(obj => obj.Email.ToUpper() == user.Email).ToList();
            if (objMail.Count > 0) { throw new Exception(Messages.ExistingMail); }
        }

        public void ValidatePasswordFormat(User user)
        {
            var matchRegex = Regex.Match(user.Password, RegularExpressions.PasswordRegx);
            if (!matchRegex.Success) { throw new Exception(Messages.FormatPasswordNotMatch); }
        }

        public void ValidateEmailFormat(User user)
        {
            var matchRegex = Regex.Match(user.Email, RegularExpressions.EmailRegx);
            if (!matchRegex.Success) { throw new Exception(Messages.FormatEmailNotMatch); }
        }

        public void ValidateExistingPassword(User user)
        {
            var objUsuario = _context.User.Where( obj => obj.UserId == user.UserId ).FirstOrDefault();
            if (objUsuario != null)
            {
                var newPassword = Cryptography.GetSHA256(user.Password);

                if(newPassword == objUsuario.Password) { throw new Exception(Messages.ItsSamePassword);}
            }
        }

        public User ValidateLogin(AuthenticateDTO auth)
        {
            var objUser = _context.User.Where(el => el.Username == auth.Username).FirstOrDefault();

            if (objUser == null) { throw new Exception(Messages.UserDontExist); }

            if(objUser.Password != Cryptography.GetSHA256(auth.Password)) { throw new Exception(Messages.ErrorAuthenticate); }

           return objUser;
        }

        #endregion

        #region Authenticate

        public TokenDTO Authenticate(AuthenticateDTO auth)
        {
            TokenDTO tokens = new TokenDTO();
            User user = ValidateLogin(auth);
            var roles = GetRolesUser(user);
            tokens.AccessToken = new GenerateToken().GenerateJWTToken(user,roles);
            tokens.RefreshToken = new TokenHandler(_context).CreateRefreshToken(user.Username);

            return tokens;
        }

        public List<Role> GetRolesUser(User user)
        {
            var objRole = from a in _context.UserRole
                          join b in _context.Role on new { a.RoleId, Active = true } equals new { b.RoleId, Active = (bool)b.Active }
                          where a.UserId == user.UserId &&
                                a.Active == true
                          select b;

            return objRole.ToList();

        }


        #endregion
    }
}

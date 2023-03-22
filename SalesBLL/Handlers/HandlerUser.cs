using SalesBLL.DTO;
using SalesBLL.Enum;
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
    public class HandlerUser
    {
        #region Constructor
        MyDbContext _context;
        public HandlerUser(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        public List<User> Get()
        {
            return _context.User.ToList();
        }

        public User? Get(int id) 
        {
            return _context.User.Where(obj => obj.UserId == id ).FirstOrDefault();
        }

        public void Post(User user) 
        {
            var objUser = user;

            ValidatePostUser(user);

            objUser.Password = Cryptography.GetSHA256(user.Password);
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
                objUser.Email= user.Email;

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
             
                _context.SaveChanges();
            }

        }

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
            var matchRegex = Regex.Match(user.Password, RegularExpressions.Password);
            if (!matchRegex.Success) { throw new Exception(Messages.FormatPasswordNotMatch); }
        }

        public void ValidateEmailFormat(User user)
        {
            var matchRegex = Regex.Match(user.Email, RegularExpressions.Email);
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

        public string Authenticate(AuthenticateDTO auth)
        {
            User user = ValidateLogin(auth);
            var roles = GetRolesUser(user);
            string jwt = new GenerateToken().GenerateJWTToken(user,roles);

            return jwt;
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

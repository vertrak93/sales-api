using SalesBLL.Constants;
using SalesBLL.DTO;
using SalesBLL.Helpers;
using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Handlers
{
    public class TokenHandler
    {

        #region Constructor
        MyDbContext _context;
        public TokenHandler(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        #region Authenticate

        public TokenDTO Authenticate(AuthenticateDTO auth)
        {
            TokenDTO tokens = new TokenDTO();

            var userHandler = new UserHandler(_context);

            User user = userHandler.ValidateLogin(auth);
            var roles = userHandler.GetRolesUser(user);

            tokens.AccessToken = new GenerateToken().GenerateJWTToken(user, roles);
            tokens.RefreshToken = CreateRefreshToken(user.Username);

            return tokens;
        }

        #endregion

        #region Refresh Token
        public void PostRefreshToken(RefreshToken refreshToken)
        {
            _context.RefreshToken.Add(refreshToken);
            _context.SaveChanges();
        }

        public void PatchRefreshToken(RefreshToken refreshToken)
        {   
            if (refreshToken != null)
            {
                _context.Update(refreshToken);
                _context.SaveChanges();
            }
        }

        public RefreshToken GetRefreshToken(string token)
        {
            var objToken = (from a in _context.RefreshToken
                           where a.Token == token && a.Active == true
                           select a).ToList().FirstOrDefault();

            if (objToken != null)
            {
                var objUser = (from a in _context.User
                               where a.UserId == objToken.UserId && a.Active == true
                               select a).ToList().FirstOrDefault();

                objToken.User = objUser;
            }

            return objToken;
        }

        public TokenDTO RefreshToken(TokenDTO tokens)
        {
            TokenDTO newTokens = new TokenDTO();
            var principal = new GenerateToken().GetClaimsPrincipalExpiredToken(tokens.AccessToken);

            var objToken = GetRefreshToken(tokens.RefreshToken);

            if(objToken.User.Username != principal.Identity.Name)
            {
                throw new Exception(Messages.InvalidUser);
            }

            if(objToken.Expiration < DateTime.UtcNow)
            {
                throw new Exception(Messages.TokenExpired);
            }

            objToken.Active = false;
            PatchRefreshToken(objToken);

            var roles = new UserHandler(_context).GetRolesUser(objToken.User);

            newTokens.AccessToken = new GenerateToken().GenerateJWTToken(objToken.User, roles);
            newTokens.RefreshToken = CreateRefreshToken(objToken.User.Username);
            
            return newTokens;
        }

        public string CreateRefreshToken(string userName)
        {
            var user = _context.User.Where(obj => obj.Username == userName).FirstOrDefault();
            DateTime now = DateTime.UtcNow;

            RefreshToken refreshToken = new RefreshToken();
            string token = new GenerateToken().GenerateRefreshToken();

            refreshToken.UserId = user.UserId;
            refreshToken.Token = token;
            refreshToken.Expiration = now.AddHours(5);
            refreshToken.Active= true;

            PostRefreshToken(refreshToken);

            return token;
        }

        #endregion

        #endregion
    }
}

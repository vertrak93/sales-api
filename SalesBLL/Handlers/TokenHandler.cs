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
        public void PostRefreshToken(RefreshToken refreshToken)
        {
            _context.RefreshToken.Add(refreshToken);
            _context.SaveChanges();
        }

        public void PatchRefreshToken(RefreshToken refreshToken)
        {
            var objToken = _context.RefreshToken.Where(obj => obj.RefreshTokenId == refreshToken.RefreshTokenId).FirstOrDefault();
            
            if (objToken != null)
            {
                objToken = refreshToken;
                _context.Update(objToken);
                _context.SaveChanges();
            }
        }

        public List<RefreshToken> GetRefreshToken(string token)
        {
            var objToken = from a in _context.RefreshToken
                           where a.Token == token && a.Active == true
                           select a;

            return objToken.ToList();
        }

        public TokenDTO RefreshToken(TokenDTO tokens)
        {
            TokenDTO newTokens = new TokenDTO();
            var principal = new GenerateToken().GetClaimsPrincipalExpiredToken(tokens.AccessToken);

            var objToken = GetRefreshToken(tokens.RefreshToken).FirstOrDefault();

            if(objToken.User.Username != principal.Identity.Name)
            {
                throw new Exception("Invalid User");
            }

            if(objToken.Expiration < DateTime.UtcNow)
            {
                throw new Exception("Token Expired");
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

            refreshToken.UserdId = user.UserId;
            refreshToken.Token = token;
            refreshToken.Expiration = now.AddHours(5);
            refreshToken.Active= true;

            PostRefreshToken(refreshToken);

            return token;
        }

        #endregion

        #region Validations

 

        #endregion
    }
}

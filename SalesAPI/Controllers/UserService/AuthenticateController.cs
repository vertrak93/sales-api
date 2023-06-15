using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesBLL.DTO;
using SalesBLL.Handlers;
using SalesDAL.Models;

namespace SalesAPI.Controllers.UserService
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        #region Constructor
        private MyDbContext _context;
        private UserHandler _userHandler;
        public AuthenticateController(MyDbContext context)
        {
            _context = context;
            _userHandler = new UserHandler(_context);
        }
        #endregion

        [HttpPost]
        [Route("")]
        public ActionResult Authenticate(AuthenticateDTO auth)
        {
            try
            {
                var result = _userHandler.Authenticate(auth);
                return Ok(new ApiResponseDTO { DATA = result });
            }
            catch (Exception ex)
            {
                return Ok(ApiResponseDTO.HandlerError(ex));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult RefresToken([FromBody]TokenDTO tokens) 
        {
            try
            {
                var result = new TokenHandler(_context).RefreshToken(tokens);
                return Ok(new ApiResponseDTO { DATA = result });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}

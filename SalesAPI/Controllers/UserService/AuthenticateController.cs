using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesBLL.DTO;
using SalesBLL.Handlers;
using SalesDAL.Models;

namespace SalesAPI.Controllers.UserService
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        #region Constructor
        private MyDbContext _context;
        public AuthenticateController(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        [HttpPost]
        [Route("")]
        public ActionResult Authenticate(AuthenticateDTO auth)
        {
            try
            {
                var result = new TokenHandler(_context).Authenticate(auth);
                return Ok(new ApiResponseDTO { DATA = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponseDTO.HandlerError(ex));
            }
        }

        [HttpPost]
        [Route("RefreshToken")]
        public ActionResult RefreshToken([FromBody]TokenDTO tokens) 
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

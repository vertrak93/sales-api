using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesBLL.DTO;
using SalesBLL.Handlers;
using SalesDAL.Models;
using System.Security.Claims;

namespace SalesAPI.Controllers.UserService
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Constructor
        private MyDbContext _context;
        private HandlerUser _userHandler;
        public UserController(MyDbContext dbcontext, IHttpContextAccessor contextAccessor)
        {
            _context = dbcontext;
            _context.SetUsername(contextAccessor.HttpContext.User.Identities.First<ClaimsIdentity>());
            _userHandler = new HandlerUser(_context);
        }
        #endregion

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = _userHandler.Get();
                return Ok(new ApiResponseDTO { DATA = result });
            }
            catch (Exception ex)
            {
                return Ok(ApiResponseDTO.HandlerError(ex));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var result = _userHandler.Get(id);
                return Ok(new ApiResponseDTO { DATA = result });
            }
            catch (Exception ex)
            {
                return Ok(ApiResponseDTO.HandlerError(ex));
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] User usr)
        {
            try
            {
                _userHandler.Post(usr);
                return Ok( new ApiResponseDTO());
            }
            catch(Exception ex)
            {
                return Ok(ApiResponseDTO.HandlerError(ex));
            }
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] User usr)
        {
            try
            {
                _userHandler.Patch(usr);
                return Ok(new ApiResponseDTO());
            }
            catch (Exception ex)
            {
                return Ok(ApiResponseDTO.HandlerError(ex));
            }
        }

        [HttpPatch]
        [Route("ChangePassword")]
        public ActionResult ChangePassword([FromBody] User usr)
        {
            try
            {
                _userHandler.ChangePassword(usr);
                return Ok(new ApiResponseDTO());
            }
            catch (Exception ex)
            {
                return Ok(ApiResponseDTO.HandlerError(ex));
            }
        }
    }
}

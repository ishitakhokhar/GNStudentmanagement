using GNStudentManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using GNStudentManagement.BAL;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLAuthController : ControllerBase
    {
        BLAuthHandler objBLAuthHandler = new BLAuthHandler();

        #region Register
        [HttpPost("register")]
        public IActionResult Register([FromBody] ACD_Student objACD_Student)
        {
            var response = objBLAuthHandler.Register(objACD_Student);
            if (!response.IsError)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        #endregion

        #region Register
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel objLoginModel)
        {
            var response = objBLAuthHandler.Login(objLoginModel);
            return Ok(response);
        }
        #endregion
    }
}



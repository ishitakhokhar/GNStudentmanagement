using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLFacultyController : ControllerBase
    {
        BLFacultyHandler objBLABLFacultyHandler = new BLFacultyHandler();
        #region login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel objLoginModel)
        {
            var response = objBLABLFacultyHandler.Login(objLoginModel);
            return Ok(response);
        }
        #endregion
    }
}

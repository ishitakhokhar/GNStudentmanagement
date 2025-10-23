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
        BLFacultyHandler objBLFacultyHandler = new BLFacultyHandler();
        #region login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel objLoginModel)
        {
            var response = objBLFacultyHandler.Login(objLoginModel);
            return Ok(response);
        }
        #endregion


        #region ProjectGroup DropDown
        [HttpGet("dropdown")]
        public IActionResult GetProjectGroupDropDown()
        {
            Response response = objBLFacultyHandler.GetProjectGroupDropDown();

            if (!response.IsError)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        #endregion
    }
}

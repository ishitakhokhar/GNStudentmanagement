using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Authorization;
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

        #region
        [HttpGet("getall")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAllFaculty()
        {
            Response response = objBLFacultyHandler.GetAllFaculty();
            if (!response.IsError)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }

        }
    #endregion

        #region 
        [HttpPost("insert")]
        [Authorize(Policy = "Admin")]
        public IActionResult Insert([FromBody] ACD_Staff objACD_Staff)
        {
            if (objACD_Staff == null)
            {
                return BadRequest(new { Message = "Invalid project group data." });
            }
            objACD_Staff.StaffId = 0;

            Response response = objBLFacultyHandler.InsertUpdate(objACD_Staff);

            if (!response.IsError)
            {
                return Ok(response);
            }

            else
            {
                return BadRequest(response);
            }
               
        }
        #endregion

        #region ProjectGroup DropDown
        [HttpGet("dropdown")]
        public IActionResult GetProjectGroupDropDown()
        {
            Response response = objBLFacultyHandler.GetFacultyDropDown();

            if (!response.IsError)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        #endregion
    }
}

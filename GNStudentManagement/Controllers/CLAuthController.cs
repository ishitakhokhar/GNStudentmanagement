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

        #region login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel objLoginModel)
        {
            var response = objBLAuthHandler.Login(objLoginModel);
            return Ok(response);
        }
        #endregion

        #region Get All Students
        [HttpGet("getall")]
        public IActionResult GetAllStudents()
        {
            Response response = objBLAuthHandler.GetAll();
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

        #region Get Project Meeting  by ID
        [HttpGet("id")]
        public IActionResult GetProjectMeetingByID([FromQuery] int StudentId)
        {
            if (StudentId <= 0)
            {
                return BadRequest();
            }
            Response response = objBLAuthHandler.GetByID(StudentId);
            if (!response.IsError)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

        #region Insert Student
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] ACD_Student objACD_Student)
        {
            if (objACD_Student == null)
            {
                return BadRequest(new { Message = "Invalid student data." });
            }

            objACD_Student.StudentId = 0;

            Response response = objBLAuthHandler.InsertUpdate(objACD_Student);

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


        #region Update Student
        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, [FromBody] ACD_Student objACD_Student)
        {
            if (objACD_Student == null || id <= 0)
            {
                return BadRequest(new { Message = "Invalid student data." });
            }

            objACD_Student.StudentId = id;

            Response response = objBLAuthHandler.InsertUpdate(objACD_Student);

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


        #region Delete Student
        [HttpDelete("id")]
        public IActionResult DeleteStudent([FromQuery] int StudentId)
        {
            Response response = objBLAuthHandler.Delete(StudentId);

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
    }
}



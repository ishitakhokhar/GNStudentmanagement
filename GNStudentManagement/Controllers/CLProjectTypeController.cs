using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CLProjectTypeController : ControllerBase
    {
        BLProjectTypeHandler objBLProjectTypeHandler = new BLProjectTypeHandler();

        #region Get All Project Types

        [HttpGet("getall")]
        [Authorize(Policy = "AdminStaffOrStudent")]
        public IActionResult GetAllProjectTypes()
        {
            Response response = objBLProjectTypeHandler.GetAllProjectTypes();
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

        [HttpGet("id")]
        [Authorize(Policy = "AdminStaffOrStudent")]
        public IActionResult GetProjectTypeByID([FromQuery] int projectTypeId)
        {
            if (projectTypeId <= 0)
                return BadRequest(new { Message = "Invalid Project Type ID." });

            Response response = objBLProjectTypeHandler.GetProjectTypeByID(projectTypeId);
            if (!response.IsError)
            {  
                return Ok(response);
            }
               
            return NotFound(response);
        }
        [HttpPost("insert")]
        [Authorize(Policy = "Admin")]
        public IActionResult Insert([FromBody] ACD_PRJ_ProjectType objACD_PRJ_ProjectType)
        {
            if (objACD_PRJ_ProjectType == null)
            {
                return BadRequest(new { Message = "Invalid project type data." });
            }
            objACD_PRJ_ProjectType.ProjectTypeId = 0;

            Response response = objBLProjectTypeHandler.InsertUpdate(objACD_PRJ_ProjectType);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }


        [HttpPut("edit/{id}")]
        [Authorize(Policy = "Admin")]
        public IActionResult Edit(int id, [FromBody] ACD_PRJ_ProjectType objACD_PRJ_ProjectType)
        {
            if (objACD_PRJ_ProjectType == null || id <= 0)
            {
                return BadRequest(new { Message = "Invalid project type data." });
            }

            objACD_PRJ_ProjectType.ProjectTypeId = id;

            Response response = objBLProjectTypeHandler.InsertUpdate(objACD_PRJ_ProjectType);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }


        [HttpDelete("id")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteProjectType([FromQuery] int projectTypeId)
        {
            Response response = objBLProjectTypeHandler.Delete(projectTypeId);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }

    }
}

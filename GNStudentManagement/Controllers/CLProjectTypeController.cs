using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProjectTypeController : ControllerBase
    {
        BLProjectTypeHandler objBLProjectTypeHandler = new BLProjectTypeHandler();

        #region Get All Project Types
        [HttpGet("getall")]
        public IActionResult GetAllProjectTypes()
        {
            List<ACD_PRJ_ProjectType> projectTypes = objBLProjectTypeHandler.GetAllProjectTypes();
            if (projectTypes != null && projectTypes.Count > 0)
            {
                return Ok(projectTypes);
            }
            return NotFound(new { Message = "No project types found." });
        }
        #endregion

        [HttpGet("id")]
        public IActionResult GetProjectTypeByID([FromQuery] int projectTypeId)
        {
            if (projectTypeId <= 0)
            {
                return BadRequest(new { Message = "Invalid Project Type ID." });
            }

            ACD_PRJ_ProjectType projectType = objBLProjectTypeHandler.GetProjectTypeByID(projectTypeId);

            if (projectType != null)
            {
                return Ok(projectType); 
            }

            return NotFound(new { Message = "Project Type not found." });
        }

        [HttpPost("insertupdate")]

        public IActionResult InsertUpdate([FromBody] ACD_PRJ_ProjectType objACD_PRJ_ProjectType)
        {
            if (objACD_PRJ_ProjectType == null)
            {
                return BadRequest(new { Message = "Invalid project type data." });
            }
            Response response = objBLProjectTypeHandler.InsertUpdate(objACD_PRJ_ProjectType);
            if (!response.IsError)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

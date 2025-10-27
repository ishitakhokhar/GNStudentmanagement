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

    public class CLProjectGroupController : ControllerBase
    {
        BLProjectGroupHandler objBLProjectGroupHandler = new BLProjectGroupHandler();

        #region Get All Project Groups

        [HttpGet("getall")]
        [Authorize(Policy ="Admin")]
        public IActionResult GetAllProjectGroups()
        {
            Response response = objBLProjectGroupHandler.GetAllProjectGroups();
            if (!response.IsError)
            {
                return Ok(response);
            }
            else {
                return NotFound(response); 
            }
            
        }
        #endregion

        #region
        [HttpGet("id")]
        [Authorize]
        public IActionResult GetProjectTypeByID([FromQuery] int projectGroupId)
        {
            if (projectGroupId <= 0)
                return BadRequest(new { Message = "Invalid Project Group ID." });

            Response response = objBLProjectGroupHandler.GetProjectGroupByID(projectGroupId);
            if (!response.IsError)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

        #region 
        [HttpPost("insert")]
        [Authorize(Policy ="Admin")]
        public IActionResult Insert([FromBody] ACD_PRJ_ProjectGroup objACD_PRJ_ProjectGroup)
        {
            if (objACD_PRJ_ProjectGroup == null)
            {
                return BadRequest(new { Message = "Invalid project group data." });
            }
            objACD_PRJ_ProjectGroup.ProjectGroupId = 0;

            Response response = objBLProjectGroupHandler.InsertUpdate(objACD_PRJ_ProjectGroup);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion



        [HttpPut("edit/{id}")]
        [Authorize(Policy ="Admin")]
        public IActionResult Edit(int id, [FromBody] ACD_PRJ_ProjectGroup objACD_PRJ_ProjectGroup)
        {
            if (objACD_PRJ_ProjectGroup == null || id <= 0)
            {
                return BadRequest(new { Message = "Invalid project type data." });
            }

            objACD_PRJ_ProjectGroup.ProjectGroupId = id;

            Response response = objBLProjectGroupHandler.InsertUpdate(objACD_PRJ_ProjectGroup);

            if (!response.IsError)
            {
                return Ok(response);
            }
              
            return BadRequest(response);
        }

        #region
        [HttpDelete("id")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteProjectType([FromQuery] int projectGroupId)
        {
            Response response = objBLProjectGroupHandler.Delete(projectGroupId);

            if (!response.IsError)
            {
                return Ok(response);
            }
                

            return BadRequest(response);
        }
        #endregion


        #region ProjectGroup DropDown
        [HttpGet("dropdown")]
        [Authorize(Policy = "AdminOrStaff")]
        public IActionResult GetProjectGroupDropDown()
        {
            Response response = objBLProjectGroupHandler.GetProjectGroupDropDown();

            if (!response.IsError)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        #endregion

    }
}

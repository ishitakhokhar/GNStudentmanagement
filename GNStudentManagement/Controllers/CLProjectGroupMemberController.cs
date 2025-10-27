using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProjectGroupMemberController : ControllerBase
    {
        BLProjectGroupMemberHandler objBLProjectGroupMemberHandler = new BLProjectGroupMemberHandler();

        #region Get All Project Group Members
        [HttpGet("getall")]
        [Authorize(Policy = "Admin,Faculty")]
        public IActionResult GetAllProjectGroupMembers()
        {
            Response response = objBLProjectGroupMemberHandler.GetAll();
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

        #region Get Project Group Member by ID
        [HttpGet("id")]
        [Authorize]
        public IActionResult GetProjectGroupMemberByID([FromQuery] int projectGroupMemberId)
        {
            if (projectGroupMemberId <= 0)
                return BadRequest(new { Message = "Invalid Project Group Member ID." });

            Response response = objBLProjectGroupMemberHandler.GetByID(projectGroupMemberId);
            if (!response.IsError)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

        #region Insert Project Group Member
        [HttpPost("insert")]
        [Authorize(Policy = "Admin")]
        public IActionResult Insert([FromBody] ACD_PRJ_ProjectGroupMember objProjectGroupMember)
        {
            if (objProjectGroupMember == null)
            {
                return BadRequest(new { Message = "Invalid Project Group Member data." });
            }

            objProjectGroupMember.ProjectGroupMemberId = 0;

            Response response = objBLProjectGroupMemberHandler.InsertUpdate(objProjectGroupMember);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Update Project Group Member
        [HttpPut("edit/{id}")]
        [Authorize(Policy = "AdminOrStaff")]
        public IActionResult Edit(int id, [FromBody] ACD_PRJ_ProjectGroupMember objProjectGroupMember)
        {
            if (objProjectGroupMember == null || id <= 0)
            {
                return BadRequest(new { Message = "Invalid Project Group Member data." });
            }

            objProjectGroupMember.ProjectGroupMemberId = id;

            Response response = objBLProjectGroupMemberHandler.InsertUpdate(objProjectGroupMember);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Delete Project Group Member
        [HttpDelete("id")]
        [Authorize(Policy ="Admin")]
        public IActionResult DeleteProjectGroupMember([FromQuery] int projectGroupMemberId)
        {
            Response response = objBLProjectGroupMemberHandler.Delete(projectGroupMemberId);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion
    }
}

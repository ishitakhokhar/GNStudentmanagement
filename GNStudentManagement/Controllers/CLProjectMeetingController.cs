using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProjectMeetingController : ControllerBase
    {
        BLProjectMeetingHandler objBLProjectMeetingHandler = new BLProjectMeetingHandler();

        #region Get All Project Meetings
        [HttpGet("getall")]
        public IActionResult GetAllProjectMeetings()
        {
            Response response = objBLProjectMeetingHandler.GetAllProjectMeetings();
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

        #region Get Project Meeting  by ID
        [HttpGet("id")]
        public IActionResult GetProjectMeetingByID([FromQuery] int ProjectMeetingId)
        {
            if (ProjectMeetingId <= 0)
                return BadRequest(new { Message = "Invalid Project Meeting  ID." });

            Response response = objBLProjectMeetingHandler.GetProjectMeetingByID(ProjectMeetingId);
            if (!response.IsError)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

        #region Insert Project Group Member
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] ACD_PRJ_ProjectMeeting objACD_PRJ_ProjectMeeting)
        {
            if (objACD_PRJ_ProjectMeeting == null)
            {
                return BadRequest(new { Message = "Invalid Project Meeting data." });
            }

            objACD_PRJ_ProjectMeeting.ProjectMeetingId = 0;

            Response response = objBLProjectMeetingHandler.Save(objACD_PRJ_ProjectMeeting);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Update Project Meeting
        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, [FromBody] ACD_PRJ_ProjectMeeting objACD_PRJ_ProjectMeeting)
        {
            if (objACD_PRJ_ProjectMeeting == null || id <= 0)
            {
                return BadRequest(new { Message = "Invalid Project Meeting data." });
            }

            objACD_PRJ_ProjectMeeting.ProjectMeetingId = id;

            Response response = objBLProjectMeetingHandler.Save(objACD_PRJ_ProjectMeeting);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Delete Project Meeting
        [HttpDelete("id")]
        public IActionResult DeleteProjectMeeting([FromQuery] int ProjectMeetingId)
        {
            Response response = objBLProjectMeetingHandler.Delete(ProjectMeetingId);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion
    }
}

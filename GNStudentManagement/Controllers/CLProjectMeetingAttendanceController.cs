using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProjectMeetingAttendanceController : ControllerBase
    {
        BLProjectMeetingAttendanceHandler objBLProjectMeetingAttendanceHandler = new BLProjectMeetingAttendanceHandler();

        #region Get All Attendance Records
        [HttpGet("getall")]
        public IActionResult GetAllAttendance()
        {
            Response response = objBLProjectMeetingAttendanceHandler.GetAll();
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

        #region Insert Attendance
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] ACD_PRJ_ProjectMeetingAttendance objACD_PRJ_ProjectMeetingAttendance)
        {
            if (objACD_PRJ_ProjectMeetingAttendance == null)
            {
                return BadRequest(new { Message = "Invalid attendance data." });
            }

            objACD_PRJ_ProjectMeetingAttendance.ProjectMeetingAttendanceId = 0;

            Response response = objBLProjectMeetingAttendanceHandler.InsertUpdate(objACD_PRJ_ProjectMeetingAttendance);

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

        #region Update Attendance
        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, [FromBody] ACD_PRJ_ProjectMeetingAttendance objACD_PRJ_ProjectMeetingAttendance)
        {
            if (objACD_PRJ_ProjectMeetingAttendance == null || id <= 0)
            {
                return BadRequest(new { Message = "Invalid attendance data." });
            }

            objACD_PRJ_ProjectMeetingAttendance.ProjectMeetingAttendanceId = id;

            Response response = objBLProjectMeetingAttendanceHandler.InsertUpdate(objACD_PRJ_ProjectMeetingAttendance);

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

        #region Delete Attendance
        [HttpDelete("id")]
        public IActionResult DeleteAttendance([FromQuery] int ProjectMeetingAttendanceID)
        {
            Response response = objBLProjectMeetingAttendanceHandler.Delete(ProjectMeetingAttendanceID);

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

using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProjectSubmissionController : ControllerBase
    {
        BLProjectSubmissionHandler objBLProjectSubmissionHandler = new BLProjectSubmissionHandler();

        #region Get All Project Submissions
        [HttpGet("getall")]
        [Authorize(Policy = "AdminOrStaff")]
        public IActionResult GetAllProjectSubmissions()
        {
            Response response = objBLProjectSubmissionHandler.GetAllProjectSubmissions();
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

        #region Get Project Submission by ID
        [HttpGet("id")]
        [Authorize(Policy = "AdminStaffOrStudent")]
        public IActionResult GetProjectSubmissionByID([FromQuery] int ProjectSubmissionId)
        {
            if (ProjectSubmissionId <= 0)
                return BadRequest(new { Message = "Invalid Project Submission ID." });

            Response response = objBLProjectSubmissionHandler.GetProjectSubmissionByID(ProjectSubmissionId);
            if (!response.IsError)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

        #region Insert Project Submission
        [HttpPost("insert")]
        [Authorize(Policy = "Student")]
        public IActionResult Insert([FromBody] ACD_PRJ_ProjectSubmission objACD_PRJ_ProjectSubmission)
        {
            if (objACD_PRJ_ProjectSubmission == null)
            {
                return BadRequest(new { Message = "Invalid Project Submission data." });
            }

            objACD_PRJ_ProjectSubmission.ProjectSubmissionID = 0;

            Response response = objBLProjectSubmissionHandler.Save(objACD_PRJ_ProjectSubmission);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Update Project Submission
        [HttpPut("edit/{id}")]
        [Authorize(Policy = "Student")]
        public IActionResult Edit(int id, [FromBody] ACD_PRJ_ProjectSubmission objACD_PRJ_ProjectSubmission)
        {
            if (objACD_PRJ_ProjectSubmission == null || id <= 0)
            {
                return BadRequest(new { Message = "Invalid Project Submission data." });
            }

            objACD_PRJ_ProjectSubmission.ProjectSubmissionID = id;

            Response response = objBLProjectSubmissionHandler.Save(objACD_PRJ_ProjectSubmission);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Delete Project Submission
        [HttpDelete("id")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteProjectSubmission([FromQuery] int ProjectSubmissionId)
        {
            Response response = objBLProjectSubmissionHandler.Delete(ProjectSubmissionId);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion
    }
}

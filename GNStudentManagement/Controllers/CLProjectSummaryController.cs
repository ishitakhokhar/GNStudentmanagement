using GNStudentManagement.BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GNStudentManagement.Models;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProjectSummaryController : ControllerBase
    {
        BLProjectSummaryHandler objBLProjectSummaryHandler=new BLProjectSummaryHandler();

        #region Get All Project Summaries
        [HttpGet("getall")]
        public IActionResult GetAllProjectSummaries()
        {
            Response response = objBLProjectSummaryHandler.GetAll();
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


        #region Get Project Group Summary by ID
        [HttpGet("id")]
        public IActionResult GetProjectMeetingByID([FromQuery] int projectGroupID)
        {
            if (projectGroupID <= 0)
                return BadRequest(new { Message = "Invalid Project Group Summary ID." });

            Response response = objBLProjectSummaryHandler.GetProjectMeetingByID(projectGroupID);
            if (!response.IsError)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}

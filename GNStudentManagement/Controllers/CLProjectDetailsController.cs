using GNStudentManagement.BAL;
using GNStudentManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GNStudentManagement.Models;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLProjectProposalController : ControllerBase
    {
        BLProjectProposalHandler objBLProjectProposalHandler = new BLProjectProposalHandler();

        #region Submit Project Proposal (Student)
        [HttpPost("submit")]
        [Authorize(Policy = "Student")]
        public IActionResult SubmitProposal([FromBody] ProjectProposalSubmitDto objProjectProposalSubmitDto)
        {
            if (objProjectProposalSubmitDto == null || objProjectProposalSubmitDto.ProjectGroupID <= 0)
            {
                return BadRequest(new { Message = "Invalid project proposal data." });
            }

            Response response = objBLProjectProposalHandler.SubmitProposal(objProjectProposalSubmitDto);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Approve/Reject Proposal (Admin)
        [HttpPut("approve/{projectGroupId}")]
        [Authorize(Policy = "Admin")]
        public IActionResult ApproveProposal(int projectGroupId, [FromBody] ProjectProposalApproveDto request)
        {
            if (projectGroupId <= 0 || string.IsNullOrEmpty(request.ProposalStatus))
            {
                return BadRequest(new { Message = "Invalid approval request." });
            }

            Response response = objBLProjectProposalHandler.ApproveProposal(projectGroupId, request.ProposalStatus, request.ApprovedBy);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Approve Project Group (Admin)
        [HttpPut("group/approve/{projectGroupId}")]
        [Authorize(Policy = "Admin")]
        public IActionResult ApproveProjectGroup(int projectGroupId, [FromBody] ProjectGroupApproveDto request)
        {
            if (projectGroupId <= 0 || request.ApprovedBy <= 0)
            {
                return BadRequest(new { Message = "Invalid approval data." });
            }

            Response response = objBLProjectProposalHandler.ApproveProjectGroup(projectGroupId, request.ApprovedBy);

            if (!response.IsError)
                return Ok(response);

            return BadRequest(response);
        }
        #endregion

        #region Get Project Details by Group
        [HttpGet("getByGroup/{projectGroupId}")]
        [Authorize(Policy = "AdminStaffOrStudent")]
        public IActionResult GetProjectDetailsByGroup(int projectGroupId)
        {
            if (projectGroupId <= 0)
                return BadRequest(new { Message = "Invalid project group ID." });

            Response response = objBLProjectProposalHandler.GetProjectDetailsByGroup(projectGroupId);

            if (!response.IsError)
                return Ok(response);

            return NotFound(response);
        }
        #endregion
    }
}

using GNStudentManagement.DAL;
using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using System.Data;

namespace GNStudentManagement.BAL
{
    public class BLProjectProposalHandler
    {
        private readonly IConfiguration _config;
        DBProjectProposalContext objDBProjectProposalContext = new DBProjectProposalContext();
        Response objResponse = new Response();

        public Response SubmitProposal(ProjectProposalSubmitDto objProjectProposalSubmitDto)
        {
            if (objProjectProposalSubmitDto == null || objProjectProposalSubmitDto.ProjectGroupID <= 0)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid project proposal data.";
            }
            else
            {
                bool success = objDBProjectProposalContext.SubmitProposal(objProjectProposalSubmitDto);
                if (success)
                {
                    objResponse.IsError = false;
                    objResponse.Message = "Project proposal submitted successfully.";
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to submit project proposal.";
                }
            }
            return objResponse;
        }

        public Response ApproveProposal(int projectGroupId, string proposalStatus, int approvedBy)
        {
            if (projectGroupId <= 0 || string.IsNullOrEmpty(proposalStatus))
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid project group or status.";
            }
            else
            {
                bool success = objDBProjectProposalContext.ApproveProposal(projectGroupId, proposalStatus, approvedBy);
                if (success)
                {
                    objResponse.IsError = false;
                    objResponse.Message = $"Project proposal {proposalStatus.ToLower()} successfully.";
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = $"Failed to {proposalStatus.ToLower()} project proposal.";
                }
            }
            return objResponse;
        }

        public Response ApproveProjectGroup(int projectGroupId, int approvedBy)
        {
            if (projectGroupId <= 0)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid project group ID.";
            }
            else
            {
                bool success = objDBProjectProposalContext.ApproveProjectGroup(projectGroupId, approvedBy);
                if (success)
                {
                    objResponse.IsError = false;
                    objResponse.Message = "Project group approved successfully.";
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to approve project group.";
                }
            }
            return objResponse;
        }

        public Response GetProjectDetailsByGroup(int projectGroupId)
        {
            DataTable dt = objDBProjectProposalContext.GetProjectDetailsByGroup(projectGroupId);

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project details loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No project details found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }
    }
}

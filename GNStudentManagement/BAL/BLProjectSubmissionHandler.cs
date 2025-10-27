using GNStudentManagement.DAL;
using GNStudentManagement.Models;
using System.Data;

namespace GNStudentManagement.BAL
{
    public class BLProjectSubmissionHandler
    {
        public readonly IConfiguration _config;
        DBProjectSubmissionContext objDBProjectSubmissionContext = new DBProjectSubmissionContext();
        Response objResponse = new Response();

        public Response GetAllProjectSubmissions()
        {
            DataTable dt = objDBProjectSubmissionContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project submissions loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No project submissions found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

        public Response GetProjectSubmissionByID(int projectSubmissionId)
        {
            Response objResponse = new Response();
            DataTable dt = objDBProjectSubmissionContext.GetByID(projectSubmissionId);

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Submission loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Project Submission not found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

        public Response InsertUpdate(ACD_PRJ_ProjectSubmission objACD_PRJ_ProjectSubmission)
        {
            Response objResponse = new Response();

            if (objACD_PRJ_ProjectSubmission == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Project Submission data.";
                objResponse.Data = new DataTable();
                return objResponse;
            }

            bool success = objDBProjectSubmissionContext.InsertUpdate(objACD_PRJ_ProjectSubmission);

            if (success)
            {
                objResponse.IsError = false;

                if (objACD_PRJ_ProjectSubmission.ProjectSubmissionID > 0)
                    objResponse.Message = "Project Submission updated successfully.";
                else
                    objResponse.Message = "Project Submission inserted successfully.";

                objResponse.Data = new DataTable();
            }
            else
            {
                objResponse.IsError = true;

                if (objACD_PRJ_ProjectSubmission.ProjectSubmissionID > 0)
                    objResponse.Message = "Failed to update Project Submission.";
                else
                    objResponse.Message = "Failed to insert Project Submission.";

                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

      
        public Response Delete(int projectSubmissionId)
        {
            Response objResponse = new Response();

            if (projectSubmissionId <= 0)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Project Submission ID.";
                objResponse.Data = new DataTable();
                return objResponse;
            }

            bool success = objDBProjectSubmissionContext.Delete(projectSubmissionId);

            if (success)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Submission deleted successfully.";
                objResponse.Data = new DataTable();
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Failed to delete Project Submission.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }
    }
}

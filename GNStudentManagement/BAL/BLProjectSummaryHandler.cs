using GNStudentManagement.DAL;
using GNStudentManagement.Models;
using System.Data;

namespace GNStudentManagement.BAL
{
    public class BLProjectSummaryHandler
    {
        public readonly IConfiguration _config;
        DBProjectSummaryContext objDBProjectSummaryContext = new DBProjectSummaryContext();
        Response objResponse = new Response();

        public Response GetAll()
        {
            DataTable dt = objDBProjectSummaryContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Summary lodaded.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No Project Summary found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }


        public Response GetProjectMeetingByID(int projectGroupID)
        {
            Response objResponse = new Response();
            DataTable dt = objDBProjectSummaryContext.GetByID(projectGroupID);

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Group summary loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Project Group Summary not found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

    }
}

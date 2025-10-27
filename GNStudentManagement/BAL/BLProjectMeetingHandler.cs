using GNStudentManagement.DAL;
using GNStudentManagement.Models;
using Newtonsoft.Json;
using System.Data;

namespace GNStudentManagement.BAL
{
    public class BLProjectMeetingHandler
    {
        public readonly IConfiguration _config;
        DBProjectMeetingContext objDBProjectMeetingContext = new DBProjectMeetingContext();
        Response objResponse = new Response();

        public Response GetAllProjectMeetings()
        {
            DataTable dt = objDBProjectMeetingContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project meetings loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No project meetings found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }


        public Response GetProjectMeetingByID(int projectMeetingId)
        {
            Response objResponse = new Response();
            DataTable dt = objDBProjectMeetingContext.GetByID(projectMeetingId);

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Meeting loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Project Meeting not found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }


        public Response InsertUpdate(ACD_PRJ_ProjectMeeting objACD_PRJ_ProjectMeeting)
        {
            Response objResponse = new Response();

            if (objACD_PRJ_ProjectMeeting == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Project Meeting data.";
                objResponse.Data = new DataTable();
                return objResponse;
            }

            bool success = objDBProjectMeetingContext.InsertUpdate(objACD_PRJ_ProjectMeeting);

            if (success)
            {
                objResponse.IsError = false;

                if (objACD_PRJ_ProjectMeeting.ProjectMeetingId > 0)
                    objResponse.Message = "Project Meeting updated successfully.";
                else
                    objResponse.Message = "Project Meeting inserted successfully.";

                objResponse.Data = new DataTable();
            }
            else
            {
                objResponse.IsError = true;

                if (objACD_PRJ_ProjectMeeting.ProjectMeetingId > 0)
                    objResponse.Message = "Failed to update Project Meeting.";
                else
                    objResponse.Message = "Failed to insert Project Meeting.";

                objResponse.Data = new DataTable();
            }

            return objResponse;
        }


      

  
        public Response Delete(int projectMeetingId)
        {
            Response objResponse = new Response();

            if (projectMeetingId <= 0)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Project Meeting ID.";
                objResponse.Data = new DataTable();
                return objResponse;
            }

            bool success = objDBProjectMeetingContext.Delete(projectMeetingId);

            if (success)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Meeting deleted successfully.";
                objResponse.Data = new DataTable();
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Failed to delete Project Meeting.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }
    }
}

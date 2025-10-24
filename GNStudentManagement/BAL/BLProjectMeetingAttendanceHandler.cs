using GNStudentManagement.DAL;
using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using System.Data;

namespace GNStudentManagement.BAL
{
    public class BLProjectMeetingAttendanceHandler
    {
        public readonly IConfiguration _config;
        DBProjectMeetingAttendanceContext objDBProjectMeetingAttendanceContext = new DBProjectMeetingAttendanceContext();
        Response objResponse = new Response();

        public Response InsertUpdate(ACD_PRJ_ProjectMeetingAttendance objACD_PRJ_ProjectMeetingAttendance)
        {
            if (objACD_PRJ_ProjectMeetingAttendance == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid attendance data.";
            }
            else
            {
                bool success = objDBProjectMeetingAttendanceContext.InsertUpdate(objACD_PRJ_ProjectMeetingAttendance);
                if (success)
                {
                    objResponse.IsError = false;
                    objResponse.Message = "Attendance saved successfully.";
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to save attendance.";
                }
            }
            return objResponse;
        }

   
        public Response Delete(int projectMeetingAttendanceID)
        {
            bool success = objDBProjectMeetingAttendanceContext.Delete(projectMeetingAttendanceID);
            if (success)
            {
                objResponse.IsError = false;
                objResponse.Message = "Attendance deleted successfully.";
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Failed to delete attendance.";
            }
            return objResponse;
        }

  
        public Response GetAll()
        {
            DataTable dt = objDBProjectMeetingAttendanceContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Attendance records loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No attendance records found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }
    }
}

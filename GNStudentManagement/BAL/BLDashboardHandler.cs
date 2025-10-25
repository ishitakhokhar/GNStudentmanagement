using GNStudentManagement.DAL;
using System.Data;
using GNStudentManagement.Models;

namespace GNStudentManagement.BAL
{
    public class BLDashboardHandler
    {
        DBDashboardContext objDBProjectMeetingAttendanceContext = new DBDashboardContext();
        Response objResponse = new Response();
        public Response GetAll()
        {
            DataTable dt = objDBProjectMeetingAttendanceContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Summary  loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No Summary found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

    }
}

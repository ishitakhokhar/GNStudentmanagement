using GNStudentManagement.DAL;
using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using System.Data;

namespace GNStudentManagement.BAL
{
    public class BLProjectGroupMemberHandler
    {
        public readonly IConfiguration _config;
        DBProjectGroupMemberContext objDBProjectGroupMemberContext = new DBProjectGroupMemberContext();
        Response objResponse = new Response();

        public Response InsertUpdate(ACD_PRJ_ProjectGroupMember objACD_PRJ_ProjectGroupMember)
        {
            if (objACD_PRJ_ProjectGroupMember == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid project group member data.";
            }
            else
            {
                bool success = objDBProjectGroupMemberContext.InsertUpdate(objACD_PRJ_ProjectGroupMember);
                if (success)
                {
                    objResponse.IsError = false;
                    objResponse.Message = "Project group member saved successfully.";
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to save project group member.";
                }
            }
            return objResponse;
        }

        public Response Delete(int projectGroupMemberID)
        {
            bool success = objDBProjectGroupMemberContext.Delete(projectGroupMemberID);
            if (success)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project group member deleted successfully.";
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Failed to delete project group member.";
            }
            return objResponse;
        }

        public Response GetByID(int projectGroupMemberID)
        {
            DataTable dt = objDBProjectGroupMemberContext.GetByID(projectGroupMemberID);

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project group member loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Project group member not found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

        public Response GetAll()
        {
            DataTable dt = objDBProjectGroupMemberContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project group members loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No project group members found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

    }
}

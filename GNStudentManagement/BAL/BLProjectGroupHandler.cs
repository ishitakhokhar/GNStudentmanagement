using GNStudentManagement.DAL;
using GNStudentManagement.Models;
using Newtonsoft.Json;
using System.Data;
using static GNStudentManagement.DAL.DBProjectGroupContext;

namespace GNStudentManagement.BAL
{
    public class BLProjectGroupHandler
    {
        public readonly IConfiguration _config;
        DBProjectGroupContext objDBProjectGroupContext = new DBProjectGroupContext();
        Response objResponse = new Response();
        public Response GetAllProjectGroups()
        {
           
            DataTable dt = objDBProjectGroupContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project groups loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No project groups found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }
        public Response GetProjectGroupByID(int projectGroupId)
        {
            Response objResponse = new Response();
            DataTable dt = objDBProjectGroupContext.GetByID(projectGroupId);

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Group loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Project Group not found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

        public Response InsertUpdate(ACD_PRJ_ProjectGroup objACD_PRJ_ProjectGroup)
        {
            Response objResponse = new Response();

            if (objACD_PRJ_ProjectGroup == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Project Group data.";
                objResponse.Data = new DataTable();
                return objResponse;
            }

            bool success = objDBProjectGroupContext.InsertUpdate(objACD_PRJ_ProjectGroup);

            if (success)
            {
                objResponse.IsError = false;

                if (objACD_PRJ_ProjectGroup.ProjectGroupId > 0)
                    objResponse.Message = "Project Group updated successfully.";
                else
                    objResponse.Message = "Project Group inserted successfully.";

                objResponse.Data = new DataTable();
            }
            else
            {
                objResponse.IsError = true;

                if (objACD_PRJ_ProjectGroup.ProjectGroupId > 0)
                    objResponse.Message = "Failed to update Project Group.";
                else
                    objResponse.Message = "Failed to insert Project Group.";

                objResponse.Data = new DataTable();
            }

            return objResponse;
        }


        public Response Delete(int projectGroupId)
        {
            Response objResponse = new Response();

            if (projectGroupId <= 0)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Project Group ID.";
                objResponse.Data = new DataTable();
                return objResponse;
            }

            bool success = objDBProjectGroupContext.Delete(projectGroupId);

            if (success)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Group deleted successfully.";
                objResponse.Data = new DataTable();
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Failed to delete Project Group.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

        public Response GetProjectGroupDropDown()
        {
            DataTable dt = objDBProjectGroupContext.GetProjectGroupDropDown();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Group dropdown loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No project groups found for dropdown.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }

    }
}

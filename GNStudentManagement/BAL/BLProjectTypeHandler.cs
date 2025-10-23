using GNStudentManagement.DAL;
using GNStudentManagement.Models;
using System.Data;
using Newtonsoft.Json;

namespace GNStudentManagement.BAL
{
    public class BLProjectTypeHandler
    {
        public readonly IConfiguration _config;
        DBProjectTypeContext objDBPProjectTypeContext = new DBProjectTypeContext();
        Response objResponse = new Response();

        public Response GetAllProjectTypes()
        {
            
            DataTable dt = objDBPProjectTypeContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project types loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No project types found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }


        public Response GetProjectTypeByID(int projectTypeId)
        {
            Response objResponse = new Response();
            DataTable dt = objDBPProjectTypeContext.GetByID(projectTypeId);

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project type loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Project type not found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }


        public Response Save(ACD_PRJ_ProjectType objACD_PRJ_ProjectType)
        {
            Response objResponse = new Response();

            if (objACD_PRJ_ProjectType == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Project Type data.";
                objResponse.Data = new DataTable();
                return objResponse;
            }

            bool success = objDBPProjectTypeContext.InsertUpdate(objACD_PRJ_ProjectType);

            if (success)
            {
                objResponse.IsError = false;

                if (objACD_PRJ_ProjectType.ProjectTypeId > 0)
                    objResponse.Message = "Project Type updated successfully.";
                else
                    objResponse.Message = "Project Type inserted successfully.";

                objResponse.Data = new DataTable();
            }
            else
            {
                objResponse.IsError = true;

                if (objACD_PRJ_ProjectType.ProjectTypeId > 0)
                    objResponse.Message = "Failed to update Project Type.";
                else
                    objResponse.Message = "Failed to insert Project Type.";

                objResponse.Data = new DataTable();
            }

            return objResponse;
        }



        public Response Delete(int projectTypeId)
        {
            Response objResponse = new Response();

            if (projectTypeId <= 0)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Project Type ID.";
                objResponse.Data = new DataTable(); 
                return objResponse;
            }

            bool success = objDBPProjectTypeContext.Delete(projectTypeId);

            if (success)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Type deleted successfully.";
                objResponse.Data = new DataTable(); 
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Failed to delete Project Type.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }


    }
}

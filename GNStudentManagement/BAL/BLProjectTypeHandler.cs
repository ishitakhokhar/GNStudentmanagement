using GNStudentManagement.DAL;
using GNStudentManagement.Models;
using System.Data;

namespace GNStudentManagement.BAL
{
    public class BLProjectTypeHandler
    {
        public readonly IConfiguration _config;
        DBProjectTypeContext objDBPProjectTypeContext = new DBProjectTypeContext();


        public List<ACD_PRJ_ProjectType> GetAllProjectTypes()
        {
            List<ACD_PRJ_ProjectType> projectTypes = new List<ACD_PRJ_ProjectType>();
            DataTable dt = objDBPProjectTypeContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    projectTypes.Add(new ACD_PRJ_ProjectType
                    {
                        ProjectTypeId = Convert.ToInt32(row["ProjectTypeID"]),
                        ProjectTypeName = row["ProjectTypeName"].ToString(),
                        Description = row["Description"].ToString(),
                        Created = Convert.ToDateTime(row["Created"]),
                        Modified = row["Modified"] == DBNull.Value ? null : Convert.ToDateTime(row["Modified"])
                    });
                }
            }

            return projectTypes;
        }


        public ACD_PRJ_ProjectType GetProjectTypeByID(int projectTypeId)
        {
            ACD_PRJ_ProjectType projectType = new ACD_PRJ_ProjectType();
            DataTable dt = objDBPProjectTypeContext.GetByID(projectTypeId);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                projectType = new ACD_PRJ_ProjectType
                {
                    ProjectTypeId = Convert.ToInt32(row["ProjectTypeID"]),
                    ProjectTypeName = row["ProjectTypeName"].ToString(),
                    Description = row["Description"].ToString(),
                    Created = Convert.ToDateTime(row["Created"]),
                    Modified = row["Modified"] == DBNull.Value ? null : Convert.ToDateTime(row["Modified"])
                };
            }

            return projectType;
        }


        public Response InsertUpdate(ACD_PRJ_ProjectType objACD_PRJ_ProjectType)
        {
            Response objResponse = new Response();
            bool success = objDBPProjectTypeContext.InsertUpdate(objACD_PRJ_ProjectType);
            if (success)
            {
                objResponse.IsError = false;
                objResponse.Message = "Project Type saved successfully.";
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Failed to save Project Type.";
            }
            return objResponse;
        }

       
    }
}

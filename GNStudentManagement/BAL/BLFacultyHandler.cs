using GNStudentManagement.DAL;
using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using System.Data;

namespace GNStudentManagement.BAL
{
    public class BLFacultyHandler
    {
        public readonly IConfiguration _config;
        DBFacultyContext objDBFacultyContext = new DBFacultyContext();
        Response objResponse = new Response();
        JWTHelper objJWTHelper = new JWTHelper();

        public object Login(LoginModel objLoginModel)
        {
            if (objLoginModel == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid data.";
            }
            else
            {
                DataTable data = objDBFacultyContext.Login(objLoginModel);
                if (data != null && data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];
                    int StaffId = Convert.ToInt32(row["StaffID"]); 
                    string email = row["Email"].ToString();
                    string name = row["StaffName"].ToString();


                    var tokenObject = objJWTHelper.GenerateJWTToken(email, StaffId, "Staff"); 

                    return new
                    {
                        IsError = false,
                        Message = "Logged in successfully.",
                        Data = new
                        {
                            StaffId = StaffId,
                            Name = name,
                            Email = email,
                            Token = ((dynamic)tokenObject).Token 
                        }
                    };
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to login staff."; 
                }
            }
            return objResponse;
        }
        public Response GetProjectGroupDropDown()
        {
            DataTable dt = objDBFacultyContext.GetProjectGroupDropDown();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Faculty dropdown loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No  faculty found for dropdown.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }
    }
}

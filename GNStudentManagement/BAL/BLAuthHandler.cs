using GNStudentManagement.DAL;
using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using System.Data;
using System.Numerics;

namespace GNStudentManagement.BAL
{
    public class BLAuthHandler
    {
        public readonly IConfiguration _config;
        DBAuthContext objDBAuthContext = new DBAuthContext();
        Response objResponse = new Response();
        JWTHelper objJWTHelper = new JWTHelper();

        public Response Register(ACD_Student objACD_Student)
        {
            if (objACD_Student == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid student data.";
            }
            else
            {
                bool success = objDBAuthContext.InsertUpdate(objACD_Student);
                if (success)
                {
                    objResponse.IsError = false;
                    objResponse.Message = "Student registered successfully.";
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to register student.";
                }
            }
            return objResponse;
        }

        public object Login(LoginModel objLoginModel)
        {
            if (objLoginModel == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid data.";
            }
            else
            {
                DataTable data = objDBAuthContext.Login(objLoginModel);
                if (data != null && data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];
                    int studentId = Convert.ToInt32(row["StudentId"]);
                    string email = row["Email"].ToString();
                    string name = row["StudentName"].ToString();

                    var tokenObject = objJWTHelper.GenerateJWTToken(email, studentId, "Student");

                    return new
                    {
                        IsError = false,
                        Message = "Logged in successfully.",
                        Data = new
                        {
                            StudentId = studentId,
                            Name = name,
                            Email = email,
                            Token = ((dynamic)tokenObject).Token // safely extract the token string
                        }
                    };
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to register Faculty.";
                }
            }
            return objResponse;
        }
    }
}

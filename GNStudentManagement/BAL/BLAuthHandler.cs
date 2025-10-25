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
                            Token = ((dynamic)tokenObject).Token 
                        }
                    };
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to register Student.";
                }
            }
            return objResponse;
        }

        public Response InsertUpdate(ACD_Student objACD_Student)
        {
            if (objACD_Student == null)
            {
                objResponse.IsError = true;
                objResponse.Message = "Invalid Student data.";
            }
            else
            {
                bool success = objDBAuthContext.InsertUpdate(objACD_Student);
                if (success)
                {
                    objResponse.IsError = false;
                    objResponse.Message = "Student saved successfully.";
                }
                else
                {
                    objResponse.IsError = true;
                    objResponse.Message = "Failed to save Student.";
                }
            }
            return objResponse;
        }

        #region Delete Student
        public Response Delete(int studentId)
        {
            bool success = objDBAuthContext.Delete(studentId);
            if (success)
            {
                objResponse.IsError = false;
                objResponse.Message = "Student deleted successfully.";
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Failed to delete student.";
            }
            return objResponse;
        }
        #endregion


        #region Get All Students
        public Response GetAll()
        {
            DataTable dt = objDBAuthContext.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Students loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "No student records found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }
        #endregion


        #region Get Student By ID
        public Response GetByID(int studentId)
        {
            DataTable dt = objDBAuthContext.GetByID(studentId);

            if (dt != null && dt.Rows.Count > 0)
            {
                objResponse.IsError = false;
                objResponse.Message = "Student loaded successfully.";
                objResponse.Data = dt;
            }
            else
            {
                objResponse.IsError = true;
                objResponse.Message = "Student not found.";
                objResponse.Data = new DataTable();
            }

            return objResponse;
        }
        #endregion
    }
}

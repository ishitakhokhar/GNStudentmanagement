using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBAuthContext : ConnectionHelper
    {
        public bool InsertUpdate(ACD_Student objACD_Student)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        if (objACD_Student.StudentId > 0)
                        {
                            dbCommand.CommandText = "ACD_Student_Update";
                            dbCommand.Parameters.Add(new SqlParameter("@StudentId", objACD_Student.StudentId));
                            dbCommand.Parameters.Add(new SqlParameter("@Modified", DateTime.Now));
                        }
                        else
                        {
                            dbCommand.CommandText = "ACD_Student_Insert";
                        }

                        dbCommand.Parameters.Add(new SqlParameter("@StudentName", objACD_Student.StudentName));
                        dbCommand.Parameters.Add(new SqlParameter("@Email", objACD_Student.Email));
                        dbCommand.Parameters.Add(new SqlParameter("@Password", HashHelper.ComputeSHA256Hash(objACD_Student.Password)));
                        dbCommand.Parameters.Add(new SqlParameter("@Phone", objACD_Student.Phone));
                        dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_Student.Description ?? (object)DBNull.Value));

                        dbCommand.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable Login(LoginModel objLoginModel)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_Student_Login";
                        dbCommand.Parameters.AddWithValue("@Email", objLoginModel.Email);
                        dbCommand.Parameters.AddWithValue("@Password", HashHelper.ComputeSHA256Hash(objLoginModel.Password));

                        using (SqlDataReader reader = dbCommand.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable GetData()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_Student_SelectAll";

                        using (SqlDataReader reader = dbCommand.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable GetByID(int studentId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_Student_SelectByID";
                        dbCommand.Parameters.Add(new SqlParameter("@StudentID", studentId));

                        using (SqlDataReader reader = dbCommand.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool Delete(int studentId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_Student_Delete";
                        dbCommand.Parameters.Add(new SqlParameter("@StudentID", studentId));
                        dbCommand.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
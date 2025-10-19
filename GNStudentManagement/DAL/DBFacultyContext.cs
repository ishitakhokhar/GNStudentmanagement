using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBFacultyContext : ConnectionHelper
    {
        public bool InsertUpdate(ACD_Staff objACD_Staff)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;

                        if (objACD_Staff.StaffId > 0)
                        {
                            dbCommand.CommandText = "ACD_Staff_Update";
                            dbCommand.Parameters.Add(new SqlParameter("@StaffId", objACD_Staff.StaffId));
                            dbCommand.Parameters.Add(new SqlParameter("@Modified", DateTime.Now));
                        }
                        else
                        {
                            dbCommand.CommandText = "ACD_Staff_Insert";
                        }

                        dbCommand.Parameters.Add(new SqlParameter("@StaffName", objACD_Staff.StaffName));
                        dbCommand.Parameters.Add(new SqlParameter("@Email", objACD_Staff.Email));
                        dbCommand.Parameters.Add(new SqlParameter("@Password",objACD_Staff.Password));
                        dbCommand.Parameters.Add(new SqlParameter("@Phone", objACD_Staff.Phone));
                        dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_Staff.Description ?? (object)DBNull.Value));

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
                        dbCommand.CommandText = "ACD_Staff_Login";
                        dbCommand.Parameters.AddWithValue("@Email", objLoginModel.Email);
                        dbCommand.Parameters.AddWithValue("@Password", objLoginModel.Password);
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
    }
}

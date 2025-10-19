using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBProjectTypeContext : ConnectionHelper
    {
        public bool InsertUpdate(ACD_PRJ_ProjectType objACD_PRJ_ProjectType)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        if (objACD_PRJ_ProjectType.ProjectTypeId > 0)
                        {
                            dbCommand.CommandText = "ACD_PRJ_ProjectType_Update";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectTypeId", objACD_PRJ_ProjectType.ProjectTypeId));
                            dbCommand.Parameters.Add(new SqlParameter("@Modified", DateTime.Now));
                        }
                        else
                        {
                            dbCommand.CommandText = "ACD_PRJ_ProjectType_Insert";
                        }
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectTypeName", objACD_PRJ_ProjectType.ProjectTypeName));
                        dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectType.Description ?? (object)DBNull.Value));
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

        public bool Delete(int ProjectTypeId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectType_Delete";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectTypeID", ProjectTypeId));
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

        public DataTable GetData()
        {
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using(SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectType_SelectAll";
                        using(SqlDataReader reader=dbCommand.ExecuteReader())
                        {
                            DataTable dt= new DataTable();
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

        public DataTable GetByID(int projectTypeId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectType_SelectByID";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectTypeID", projectTypeId));

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

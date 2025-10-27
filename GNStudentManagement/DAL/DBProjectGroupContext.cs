using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBProjectGroupContext : ConnectionHelper
    {
        public bool InsertUpdate(ACD_PRJ_ProjectGroup objACD_PRJ_ProjectGroup)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;

                        if (objACD_PRJ_ProjectGroup.ProjectGroupId > 0)
                        {
                           
                            dbCommand.CommandText = "ACD_PRJ_ProjectGroup_Update";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", objACD_PRJ_ProjectGroup.ProjectGroupId));
                            dbCommand.Parameters.Add(new SqlParameter("@Modified", DateTime.Now));
                        }
                        else
                        {
                            
                            dbCommand.CommandText = "ACD_PRJ_ProjectGroup_Insert";
                        }

                       
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupName", objACD_PRJ_ProjectGroup.ProjectGroupName));
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectTypeID", objACD_PRJ_ProjectGroup.ProjectTypeId));
                        dbCommand.Parameters.Add(new SqlParameter("@GuideStaffID", objACD_PRJ_ProjectGroup.GuideStaffID));
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectTitle", objACD_PRJ_ProjectGroup.ProjectTitle));
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectArea", objACD_PRJ_ProjectGroup.ProjectArea));
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectDescription", objACD_PRJ_ProjectGroup.ProjectDescription));
                        dbCommand.Parameters.Add(new SqlParameter("@AverageCPI", objACD_PRJ_ProjectGroup.AverageCpi));
                        dbCommand.Parameters.Add(new SqlParameter("@ConvenerStaffID", objACD_PRJ_ProjectGroup.ConvenerStaffId));
                        dbCommand.Parameters.Add(new SqlParameter("@ExpertStaffID", objACD_PRJ_ProjectGroup.ExpertStaffId));
                        dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectGroup.Description ?? (object)DBNull.Value));

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

        public bool Delete(int ProjectGroupId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectGroup_Delete";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", ProjectGroupId));
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
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectGroup_SelectAll";
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

        public DataTable GetByID(int ProjectGroupId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectGroup_SelectByID";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", ProjectGroupId));

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


            public DataTable GetProjectGroupDropDown()
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                    {
                        sqlConnection.Open();
                        using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                        {
                            dbCommand.CommandType = CommandType.StoredProcedure;
                            dbCommand.CommandText = "ACD_PRJ_ProjectGroup_DropDown";

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


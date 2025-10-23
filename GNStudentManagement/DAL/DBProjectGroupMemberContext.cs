using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBProjectGroupMemberContext : ConnectionHelper
    {
        public bool InsertUpdate(ACD_PRJ_ProjectGroupMember objACD_PRJ_ProjectGroupMember)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;

                        if (objACD_PRJ_ProjectGroupMember.ProjectGroupMemberId > 0)
                        {
                            dbCommand.CommandText = "ACD_PRJ_ProjectGroupMember_Update";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupMemberID", objACD_PRJ_ProjectGroupMember.ProjectGroupMemberId));
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", objACD_PRJ_ProjectGroupMember.ProjectGroupId));
                            dbCommand.Parameters.Add(new SqlParameter("@StudentID", objACD_PRJ_ProjectGroupMember.StudentId));
                            dbCommand.Parameters.Add(new SqlParameter("@IsGroupLeader", objACD_PRJ_ProjectGroupMember.IsGroupLeader));
                            dbCommand.Parameters.Add(new SqlParameter("@StudentCGPA", objACD_PRJ_ProjectGroupMember.StudentCgpa));
                            dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectGroupMember.Description));
                        }
                        else
                        {
                            dbCommand.CommandText = "ACD_PRJ_ProjectGroupMember_Insert";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", objACD_PRJ_ProjectGroupMember.ProjectGroupId));
                            dbCommand.Parameters.Add(new SqlParameter("@StudentID", objACD_PRJ_ProjectGroupMember.StudentId));
                            dbCommand.Parameters.Add(new SqlParameter("@IsGroupLeader", objACD_PRJ_ProjectGroupMember.IsGroupLeader));
                            dbCommand.Parameters.Add(new SqlParameter("@StudentCGPA", objACD_PRJ_ProjectGroupMember.StudentCgpa));
                            dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectGroupMember.Description));
                        }

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

        public bool Delete(int ProjectGroupMemberID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectGroupMember_Delete";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupMemberID", ProjectGroupMemberID));
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
                        dbCommand.CommandText = "ACD_PRJ_ProjectGroupMember_SelectAll";
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

        public DataTable GetByID(int ProjectGroupMemberID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectGroupMember_SelectByID";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupMemberID", ProjectGroupMemberID));

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

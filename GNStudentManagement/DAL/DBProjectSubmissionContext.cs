using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBProjectSubmissionContext : ConnectionHelper
    {
        public bool InsertUpdate(ACD_PRJ_ProjectSubmission objACD_PRJ_ProjectSubmission)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;

                  
                        if (objACD_PRJ_ProjectSubmission.ProjectSubmissionID > 0)
                        {
                            dbCommand.CommandText = "ACD_PRJ_ProjectSubmission_Update";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectSubmissionID", objACD_PRJ_ProjectSubmission.ProjectSubmissionID));
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", objACD_PRJ_ProjectSubmission.ProjectGroupID));
                            dbCommand.Parameters.Add(new SqlParameter("@StudentID", objACD_PRJ_ProjectSubmission.StudentID));
                            dbCommand.Parameters.Add(new SqlParameter("@SubmissionLink", objACD_PRJ_ProjectSubmission.SubmissionLink));
                            dbCommand.Parameters.Add(new SqlParameter("@SubmissionRemarks", objACD_PRJ_ProjectSubmission.SubmissionRemarks ?? (object)DBNull.Value));
                            dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectSubmission.Description ?? (object)DBNull.Value));
                        }
               
                        else
                        {
                            dbCommand.CommandText = "ACD_PRJ_ProjectSubmission_Insert";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", objACD_PRJ_ProjectSubmission.ProjectGroupID));
                            dbCommand.Parameters.Add(new SqlParameter("@StudentID", objACD_PRJ_ProjectSubmission.StudentID));
                            dbCommand.Parameters.Add(new SqlParameter("@SubmissionLink", objACD_PRJ_ProjectSubmission.SubmissionLink));
                            dbCommand.Parameters.Add(new SqlParameter("@SubmissionRemarks", objACD_PRJ_ProjectSubmission.SubmissionRemarks ?? (object)DBNull.Value));
                            dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectSubmission.Description ?? (object)DBNull.Value));
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

        public bool Delete(int ProjectSubmissionID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectSubmission_Delete";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectSubmissionID", ProjectSubmissionID));
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
                        dbCommand.CommandText = "ACD_PRJ_ProjectSubmission_SelectAll";
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

        public DataTable GetByID(int ProjectSubmissionID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectSubmission_SelectByID";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectSubmissionID", ProjectSubmissionID));

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

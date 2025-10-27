using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBProjectMeetingContext: ConnectionHelper
    {
        public bool InsertUpdate(ACD_PRJ_ProjectMeeting objACD_PRJ_ProjectMeeting)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;

                        if (objACD_PRJ_ProjectMeeting.ProjectMeetingId > 0)
                        {
                            
                            dbCommand.CommandText = "ACD_PRJ_ProjectMeeting_Update";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectMeetingID", objACD_PRJ_ProjectMeeting.ProjectMeetingId));
                            dbCommand.Parameters.Add(new SqlParameter("@Modified", DateTime.Now));
                        }
                        else
                        {
                       
                            dbCommand.CommandText = "ACD_PRJ_ProjectMeeting_Insert";
                        }

                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", objACD_PRJ_ProjectMeeting.ProjectGroupId));
                        dbCommand.Parameters.Add(new SqlParameter("@GuideStaffID", objACD_PRJ_ProjectMeeting.GuideStaffId));
                        dbCommand.Parameters.Add(new SqlParameter("@MeetingDateTime", objACD_PRJ_ProjectMeeting.MeetingDateTime));
                        dbCommand.Parameters.Add(new SqlParameter("@MeetingPurpose", objACD_PRJ_ProjectMeeting.MeetingPurpose ?? (object)DBNull.Value));
                        dbCommand.Parameters.Add(new SqlParameter("@MeetingLocation", objACD_PRJ_ProjectMeeting.MeetingLocation ?? (object)DBNull.Value));
                        dbCommand.Parameters.Add(new SqlParameter("@MeetingNotes", objACD_PRJ_ProjectMeeting.MeetingNotes ?? (object)DBNull.Value));
                        dbCommand.Parameters.Add(new SqlParameter("@MeetingStatus", objACD_PRJ_ProjectMeeting.MeetingStatus ?? (object)DBNull.Value));
                        dbCommand.Parameters.Add(new SqlParameter("@MeetingStatusDescription", objACD_PRJ_ProjectMeeting.MeetingStatusDescription ?? (object)DBNull.Value));
                        dbCommand.Parameters.Add(new SqlParameter("@MeetingStatusDatetime", objACD_PRJ_ProjectMeeting.MeetingStatusDatetime));
                        dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectMeeting.Description ?? (object)DBNull.Value));

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


        public bool Delete(int ProjectMeetingID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectMeeting_Delete";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectMeetingID", ProjectMeetingID));
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
                        dbCommand.CommandText = "ACD_PRJ_ProjectMeeting_SelectAll";
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

        public DataTable GetByID(int ProjectMeetingID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectMeeting_SelectByID";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectMeetingID", ProjectMeetingID));

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

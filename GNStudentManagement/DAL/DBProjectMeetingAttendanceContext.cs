using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBProjectMeetingAttendanceContext : ConnectionHelper
    {
        public bool InsertUpdate(ACD_PRJ_ProjectMeetingAttendance objACD_PRJ_ProjectMeetingAttendance)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;

                        if (objACD_PRJ_ProjectMeetingAttendance.ProjectMeetingAttendanceId > 0)
                        {
                            dbCommand.CommandText = "ACD_PRJ_ProjectMeetingAttendance_Update";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectMeetingAttendanceID", objACD_PRJ_ProjectMeetingAttendance.ProjectMeetingAttendanceId));
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectMeetingID", objACD_PRJ_ProjectMeetingAttendance.ProjectMeetingId));
                            dbCommand.Parameters.Add(new SqlParameter("@StudentID", objACD_PRJ_ProjectMeetingAttendance.StudentId));
                            dbCommand.Parameters.Add(new SqlParameter("@IsPresent", objACD_PRJ_ProjectMeetingAttendance.IsPresent));
                            dbCommand.Parameters.Add(new SqlParameter("@AttendanceRemarks", objACD_PRJ_ProjectMeetingAttendance.AttendanceRemarks ));
                            dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectMeetingAttendance.Description));
                        }
                        else
                        {
                            dbCommand.CommandText = "ACD_PRJ_ProjectMeetingAttendance_Insert";
                            dbCommand.Parameters.Add(new SqlParameter("@ProjectMeetingID", objACD_PRJ_ProjectMeetingAttendance.ProjectMeetingId));
                            dbCommand.Parameters.Add(new SqlParameter("@StudentID", objACD_PRJ_ProjectMeetingAttendance.StudentId));
                            dbCommand.Parameters.Add(new SqlParameter("@IsPresent", objACD_PRJ_ProjectMeetingAttendance.IsPresent));
                            dbCommand.Parameters.Add(new SqlParameter("@AttendanceRemarks", objACD_PRJ_ProjectMeetingAttendance.AttendanceRemarks));
                            dbCommand.Parameters.Add(new SqlParameter("@Description", objACD_PRJ_ProjectMeetingAttendance.Description ));
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

        public bool Delete(int projectMeetingAttendanceID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectMeetingAttendance_Delete";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectMeetingAttendanceID", projectMeetingAttendanceID));
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
                        dbCommand.CommandText = "ACD_PRJ_ProjectMeetingAttendance_SelectAll";

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

        public DataTable GetByID(int projectMeetingAttendanceID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectMeetingAttendance_SelectByID";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectMeetingAttendanceID", projectMeetingAttendanceID));

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

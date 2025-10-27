using GNStudentManagement.Helpers;
using GNStudentManagement.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GNStudentManagement.DAL
{
    public class DBProjectProposalContext : ConnectionHelper
    {
   
        public bool SubmitProposal(ProjectProposalSubmitDto objProjectProposalSubmitDto)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectProposal_Submit";

                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", objProjectProposalSubmitDto.ProjectGroupID));
                        dbCommand.Parameters.Add(new SqlParameter("@ProposalDoc", objProjectProposalSubmitDto.ProposalDoc));
                        dbCommand.Parameters.Add(new SqlParameter("@Description", objProjectProposalSubmitDto.Description));

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

        public bool ApproveProposal(int projectGroupId, string proposalStatus, int approvedBy)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectProposal_Approve";

                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", projectGroupId));
                        dbCommand.Parameters.Add(new SqlParameter("@ProposalStatus", proposalStatus));
                        dbCommand.Parameters.Add(new SqlParameter("@ApprovedBy", approvedBy));

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

        public bool ApproveProjectGroup(int projectGroupId, int approvedBy)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (DbCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectGroup_Approve";

                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", projectGroupId));
                        dbCommand.Parameters.Add(new SqlParameter("@ApprovedBy", approvedBy));

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

        public DataTable GetProjectDetailsByGroup(int projectGroupId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand dbCommand = sqlConnection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        dbCommand.CommandText = "ACD_PRJ_ProjectDetails_SelectByGroup";
                        dbCommand.Parameters.Add(new SqlParameter("@ProjectGroupID", projectGroupId));

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

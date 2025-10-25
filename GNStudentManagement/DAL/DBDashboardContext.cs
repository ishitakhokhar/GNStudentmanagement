using GNStudentManagement.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;
namespace GNStudentManagement.DAL
{
    public class DBDashboardContext:ConnectionHelper
    {
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
                        dbCommand.CommandText = "ACD_RPT_Dashboard_Summary";

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

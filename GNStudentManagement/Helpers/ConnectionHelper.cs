namespace GNStudentManagement.Helpers
{
    public class ConnectionHelper
    {
        #region Connection String
        public static string ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("GNStudentManagement");
        #endregion
    }
}

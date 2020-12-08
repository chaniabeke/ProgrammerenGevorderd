using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataLayer.Tools
{
    public static class Util
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            return configuration.GetConnectionString("CustomerOrderProductDB").ToString();
        }
        public static SqlConnection GetSqlConnection(string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}

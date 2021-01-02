using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace DataLayer.Tests.Utils
{

    public class ToolKit
    {

        public static void ResetTables()
        {
            string connectionString = GetConnectionString();
            DropTables(connectionString);
            CreateTables(connectionString);
        }

        private static void DropTables(string target)
        {
            string path = @".\..\..\..\Utils\DropTables.sql";
            Console.WriteLine("Dropping tables...");
            ExecuteQueryFromFile(path, target);
        }

        private static void CreateTables(string target)
        {
            string path = @".\..\..\..\Utils\CreateTables.sql";
            Console.WriteLine("Creating tables...");
            ExecuteQueryFromFile(path, target);
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            return configuration.GetConnectionString("CustomerOrderProductDB").ToString();
        }

        private static void ExecuteQueryFromFile(string path, string target)
        {
            string sql = File.ReadAllText(path);

            using (SqlConnection conn = new SqlConnection(target))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
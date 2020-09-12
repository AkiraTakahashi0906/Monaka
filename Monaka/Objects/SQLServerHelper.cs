using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monaka.Objects
{
    internal static class SQLServerHelper
    {
        internal static string ConnectionString = @"";

        static SQLServerHelper()
        {
            var builder = new SqlConnectionStringBuilder();
            //builder.DataSource = @"DESKTOP-8B0KCU1\SQLEXPRESS";
            //builder.InitialCatalog = "Monaka";
            //builder.IntegratedSecurity = true; //windows認証true sqlserver認証false
            //builder.UserID = "akira";
            //builder.Password = "akira";

            builder.DataSource = System.Configuration.ConfigurationManager.AppSettings["DataSource"] ;
            builder.InitialCatalog = System.Configuration.ConfigurationManager.AppSettings["InitialCatalog"];
            builder.IntegratedSecurity = System.Configuration.ConfigurationManager.AppSettings["IntegratedSecurity"] == "1";
            builder.UserID = System.Configuration.ConfigurationManager.AppSettings["UserID"];
            builder.Password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            ConnectionString = builder.ToString();
        }

        internal static void Execute(
            string sql,
            SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using(var command = new SqlCommand(sql, connection))
            {
                connection.Open();

                if(parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                command.ExecuteNonQuery();
            }
        }

    }
}

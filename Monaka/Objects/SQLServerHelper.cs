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
            builder.DataSource = @"DESKTOP-8B0KCU1\SQLEXPRESS";
            builder.InitialCatalog = "Monaka";
            builder.IntegratedSecurity = true;
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

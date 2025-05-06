using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace IN451_Unit9.Services
{
    public class SqlConnectionTester
    {
        public static bool TestConnection(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true; // Connection is successful
                }
            }
            catch (Exception ex)
            {
                return false; // Connection failed
            }
        }
    }
}

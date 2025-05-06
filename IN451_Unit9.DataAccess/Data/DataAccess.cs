using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace IN451_Unit9.DataAccess.Data
{
    public class DataAccess
    {
        private readonly string _connectionString;

        // Inject IHttpContextAccessor to access the session
        public DataAccess(IHttpContextAccessor httpContextAccessor)
        {
            // Retrieve connection string from session
            _connectionString = httpContextAccessor.HttpContext.Session.GetString("ConnectionString");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string not found in session.");
            }
        }

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets all Customers from Northwind Database
        /// </summary>
        /// <returns>Entire Customers Object</returns>
        public List<Dictionary<string, object>> GetCustomers()
        {

            var customers = new List<Dictionary<string, object>>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var query = "SELECT * FROM dbo.Customers";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader.GetValue(i);
                                }
                                customers.Add(row);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                
                // Rethrowing the exception or custom handling:
                throw new InvalidOperationException("An error occurred while accessing the database. Please check your permissions.", ex);
            }

            return customers;
        }

        /// <summary>
        /// Gets all Employees from Northwind Database
        /// </summary>
        /// <returns>Entire Employees Object</returns>
        public List<Dictionary<string, object>> GetEmployees()
        {
            var employees = new List<Dictionary<string, object>>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var query = "SELECT * FROM dbo.Employees";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Loop through Employees table and get values
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader.GetValue(i);
                                }
                                employees.Add(row);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                // Rethrowing the exception or custom handling:
                throw new InvalidOperationException("An error occurred while accessing the database. Please check your permissions.", ex);
            }
            

            return employees;
        }

        /// <summary>
        /// Gets all Orders from Northwind Database
        /// </summary>
        /// <returns>Entire Orders Object</returns>
        public List<Dictionary<string, object>> GetOrders()
        {
            var orders = new List<Dictionary<string, object>>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var query = "SELECT * FROM dbo.Orders";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Loop through Orders table and get values
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader.GetValue(i);
                                }
                                orders.Add(row);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                // Rethrowing the exception or custom handling:
                throw new InvalidOperationException("An error occurred while accessing the database. Please check your permissions.", ex);
            }
            

            return orders;
        }

    }
}

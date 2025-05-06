using IN451_Unit9.DataAccess.Data;
using IN451_Unit9.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using IN451_Unit9.Models;
using IN451_Unit9.Services;

namespace IN451_Unit9.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _connectionString;

        public EmployeeService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // Retrieve connection string from session
            _connectionString = _httpContextAccessor.HttpContext.Session.GetString("ConnectionString");
        }

        // Gets all orders
        public List<Employees> GetAllEmployees()
        {
            // Check if string exists
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string not available.");
            }

            var dataAccess = new DataAccess.Data.DataAccess(_connectionString); 

            var rawEmployees = dataAccess.GetEmployees();

            var employees = new List<Employees>();

            // Map raw data to Employees model
            foreach (var rawEmployee in rawEmployees)
            {
                var employee = new Employees
                {
                    EmployeeID = Convert.ToInt32(rawEmployee["EmployeeID"]),
                    LastName = rawEmployee["LastName"]?.ToString(),
                    FirstName = rawEmployee["FirstName"]?.ToString(),
                    Title = rawEmployee["Title"]?.ToString(),
                    TitleOfCourtesy = rawEmployee["TitleOfCourtesy"]?.ToString(),
                    BirthDate = rawEmployee["BirthDate"] as DateTime?,
                    HireDate = rawEmployee["HireDate"] as DateTime?,
                    Address = rawEmployee["Address"]?.ToString(),
                    City = rawEmployee["City"]?.ToString(),
                    Region = rawEmployee["Region"]?.ToString(),
                    PostalCode = rawEmployee["PostalCode"]?.ToString(),
                    Country = rawEmployee["Country"]?.ToString(),
                    HomePhone = rawEmployee["HomePhone"]?.ToString(),
                    Salary = rawEmployee["Salary"] as decimal?,
                    Extension = rawEmployee["Extension"]?.ToString(),
                    Photo = rawEmployee["Photo"] as byte[],
                    Notes = rawEmployee["Notes"]?.ToString(),
                    ReportsTo = rawEmployee["ReportsTo"] as int?,
                    PhotoPath = rawEmployee["PhotoPath"]?.ToString()
                };
                employees.Add(employee);
            }

            return employees;
        }

        // Gets Employee total count
        public int GetEmployeeCount()
        {
            var employees = GetAllEmployees();
            return employees.Count;
        }
    }
}

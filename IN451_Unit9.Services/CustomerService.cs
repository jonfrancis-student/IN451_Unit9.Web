using IN451_Unit9.DataAccess.Data;
using IN451_Unit9.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using IN451_Unit9.Models;
using IN451_Unit9.Services;

namespace IN451_Unit9.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _connectionString;

        // Inject IHttpContextAccessor to access session
        public CustomerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // Retrieve connection string from session
            _connectionString = _httpContextAccessor.HttpContext.Session.GetString("ConnectionString");
        }

        // Fetch all customers using DataAccess
        public List<Customers> GetAllCustomers()
        {
            //Check if string exists
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string not available.");
            }

            var dataAccess = new DataAccess.Data.DataAccess(_connectionString);
            var customerData = dataAccess.GetCustomers();

            var customers = new List<Customers>();

            // Map raw data to Customers model
            foreach (var rawCustomer in customerData)
            {
                var customer = new Customers
                {
                    CustomerID = rawCustomer["CustomerID"].ToString()!,
                    CompanyName = rawCustomer["CompanyName"]?.ToString(),
                    ContactName = rawCustomer["ContactName"]?.ToString(),
                    ContactTitle = rawCustomer["ContactTitle"]?.ToString(),
                    Address = rawCustomer["Address"]?.ToString(),
                    City = rawCustomer["City"]?.ToString(),
                    Region = rawCustomer["Region"]?.ToString(),
                    PostalCode = rawCustomer["PostalCode"]?.ToString(),
                    Country = rawCustomer["Country"]?.ToString(),
                    Phone = rawCustomer["Phone"]?.ToString(),
                    Fax = rawCustomer["Fax"]?.ToString()
                };
                customers.Add(customer);
            }
            return customers;
        }

        // Get the total count of customers
        public int GetCustomerCount()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string not available.");
            }

            var dataAccess = new DataAccess.Data.DataAccess(_connectionString);
            var customerData = dataAccess.GetCustomers(); 

            return customerData.Count;  // Get the count
        }
    }
}

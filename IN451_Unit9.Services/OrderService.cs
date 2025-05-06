using IN451_Unit9.DataAccess.Data;
using IN451_Unit9.Models;
using IN451_Unit9.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace IN451_Unit9.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _connectionString;

        public OrderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // Retrieve connection string from session
            _connectionString = _httpContextAccessor.HttpContext.Session.GetString("ConnectionString");
        }

        public List<Orders> GetAllOrders()
        {
            // Check if string exists
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string not available.");
            }

            var dataAccess = new DataAccess.Data.DataAccess(_connectionString);


            var rawOrders = dataAccess.GetOrders();
            var orders = new List<Orders>();

            foreach (var rawOrder in rawOrders)
            {
                var order = new Orders
                {
                    OrderID = Convert.ToInt32(rawOrder["OrderID"]),
                    CustomerID = rawOrder["CustomerID"]?.ToString(),
                    EmployeeID = rawOrder["EmployeeID"] as int?,
                    OrderDate = rawOrder["OrderDate"] as DateTime?,
                    RequiredDate = rawOrder["RequiredDate"] as DateTime?,
                    ShippedDate = rawOrder["ShippedDate"] as DateTime?,
                    ShipVia = rawOrder["ShipVia"] as int?,
                    Freight = rawOrder["Freight"] as decimal?,
                    ShipName = rawOrder["ShipName"]?.ToString(),
                    ShipAddress = rawOrder["ShipAddress"]?.ToString(),
                    ShipCity = rawOrder["ShipCity"]?.ToString(),
                    ShipRegion = rawOrder["ShipRegion"]?.ToString(),
                    ShipPostalCode = rawOrder["ShipPostalCode"]?.ToString(),
                    ShipCountry = rawOrder["ShipCountry"]?.ToString()
                };
                orders.Add(order);
            }

            return orders;
        }

        // Gets order total count
        public int GetOrderCount()
        {
            var orders = GetAllOrders();
            return orders.Count;
        }
    }
}

using IN451_Unit9.Models;

namespace IN451_Unit9.Services.Interfaces
{
    public interface ICustomerService
    {
        // Fetches all customers from the database
        List<Customers> GetAllCustomers();

        // Fetches the count of all customers
        int GetCustomerCount();
    }
}

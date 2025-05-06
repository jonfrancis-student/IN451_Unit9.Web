using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IN451_Unit9.Models;

namespace IN451_Unit9.Services.Interfaces
{
    public interface IOrderService
    {
        // Gets all orders
        List<Orders> GetAllOrders();
        // Gets order count
        int GetOrderCount();
    }
}

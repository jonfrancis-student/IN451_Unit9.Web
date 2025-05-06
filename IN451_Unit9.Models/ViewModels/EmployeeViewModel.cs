using System.Collections.Generic;
using IN451_Unit9.Models;

namespace IN451_Unit9.Models.ViewModels
{
    public class EmployeeViewModel
    {
        // List of employees
        public List<Employees>? Employees { get; set; }

        // Total count of employees
        public int? EmployeeCount { get; set; }
    }
}

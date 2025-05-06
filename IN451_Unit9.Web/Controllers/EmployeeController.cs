using IN451_Unit9.Models.ViewModels;
using IN451_Unit9.Services;
using IN451_Unit9.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IN451_Unit9.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            try
            {
                // Fetch data using the service
                var employees = _employeeService.GetAllEmployees();
                var employeeCount = _employeeService.GetEmployeeCount();

                // Create a ViewModel and populate it
                var viewModel = new EmployeeViewModel
                {
                    Employees = employees,
                    EmployeeCount = employeeCount
                };

                // Pass the ViewModel to the view
                return View(viewModel);
            }
            catch (InvalidOperationException ex)
            {
                // Log or handle the exception as needed
                TempData["ErrorMessage"] = ex.Message;  // Store error message to show on Error page (Dev)
                return RedirectToAction("Error401", "Home");
            }
            

            
        }
    }
}

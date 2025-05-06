using IN451_Unit9.Models.ViewModels;
using IN451_Unit9.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IN451_Unit9.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            try
            {
                // Fetch data using the service
                var customers = _customerService.GetAllCustomers();
                var customerCount = _customerService.GetCustomerCount();

                // Create a ViewModel and populate it
                var viewModel = new CustomerViewModel
                {
                    Customers = customers,
                    CustomerCount = customerCount
                };

                // Pass the ViewModel to the view
                return View(viewModel);
            }
            catch(InvalidOperationException ex)
            {
                // Log or handle the exception as needed
                TempData["ErrorMessage"] = ex.Message;  // Store error message to show on Error page (Dev)
                return RedirectToAction("Error401", "Home");
            }
            
        }
    }
}

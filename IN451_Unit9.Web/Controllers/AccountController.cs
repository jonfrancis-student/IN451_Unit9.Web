using Microsoft.AspNetCore.Mvc;
using IN451_Unit9.Models.Config;
using IN451_Unit9.Services;
using IN451_Unit9.Services.Interfaces;


namespace IN451_Unit9.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly IOrderService _orderService;

        public AccountController(ICustomerService customerService, IEmployeeService employeeService, IOrderService orderService)
        {
            _customerService = customerService;
            _employeeService = employeeService;
            _orderService = orderService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(SqlConnectionInfo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Construct the connection string from user input
                    string connectionString = $"Server={model.Server};Database={model.Database};User Id={model.User};Password={model.Password};TrustServerCertificate=true;";

                    // Test the connection to the database
                    if (!SqlConnectionTester.TestConnection(connectionString))
                    {
                        TempData["ErrorMessage"] = "Invalid Credentials!";
                        return RedirectToAction("Index", "Account"); // Return the view with the error message
                    }

                    // Store the connection string in the session to be used later by other controllers
                    HttpContext.Session.SetString("ConnectionString", connectionString);
                    HttpContext.Session.SetString("Username", model.User);

                    // Redirect to Home or any other page
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Login Failed. Please try again.";

                }
            }

            return View(model);
        }

       
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the Login page
            return RedirectToAction("Index", "Account");
        }
    }
}

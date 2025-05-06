using Microsoft.AspNetCore.Mvc;
using IN451_Unit9.Services.Interfaces;
using IN451_Unit9.Models.ViewModels;

namespace IN451_Unit9.Web.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error401()
    {
        return View();
    }
}

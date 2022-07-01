using LCO_2_0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ShopBridge.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

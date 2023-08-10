using WS.MVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WS.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index() => View();
        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
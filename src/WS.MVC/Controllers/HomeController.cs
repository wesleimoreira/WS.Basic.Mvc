using Microsoft.AspNetCore.Mvc;

namespace WS.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() { }
        public IActionResult Index() => CustomView<ViewResult>("Index");
        public IActionResult Privacy() => CustomView<ViewResult>("Privacy");
    }
}
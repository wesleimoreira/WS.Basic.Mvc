using Microsoft.AspNetCore.Mvc;

namespace WS.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IActionResult CustomView<T>(string? viewName, object? model = null, int statusCode = 0)
        {
            if (typeof(T).Equals(typeof(ViewResult)))
            {
                var resultView = View(viewName, model);
                resultView.StatusCode = statusCode;
                return resultView;
            }
            else
            {
                var resultRedirect = RedirectToAction(viewName, model);
                return resultRedirect;
            }
        }
    }
}
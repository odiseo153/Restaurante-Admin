using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Manager.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

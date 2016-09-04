using Microsoft.AspNetCore.Mvc;

namespace KPITV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ErrorStatus(string id)
        {
            return Content($"Code: {id}");
        }
    }
}

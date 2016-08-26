using KPITV.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace KPITV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            VK vk = new VK();
            var lol = vk.GetMembers();
            return View();
        }
    }
}

using KPITV.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KPITV.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            VK lol = new VK();
            var loll = await lol.GetVKLink(await lol.GetId("stasphere"));
            return View();
        }

        public IActionResult ErrorStatus(string id)
        {
            return Content($"Code: {id}");
        }
    }
}

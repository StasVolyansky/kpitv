using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using KPITV.Models;
using KPITV.Models.BusinessLogic;
using KPITV.Models.Data;
using KPITV.Models.ProfileViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KPITV.Controllers
{
    //[Authorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        ApplicationDbContext db;
        readonly UserManager<ApplicationUser> userManager;

        public ProfileController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            this.db = db;
            this.userManager = userManager;
        }

        [Route("{profileLink}")]
        public IActionResult Index(string profileLink)
        {
            ProfileViewModel user = userManager.FindByProfileLink(db, profileLink);
            return View(user);
        }

        [HttpGet]
        [Authorize(Roles ="Member")]
        public IActionResult Settings()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Settings()
        //{

        //}
    }
}

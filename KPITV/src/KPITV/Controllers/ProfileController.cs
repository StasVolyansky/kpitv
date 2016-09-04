using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using KPITV.Models;
using KPITV.Models.BusinessLogic;
using KPITV.Models.Data;
using KPITV.Models.ProfileViewModels;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace KPITV.Controllers
{

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
        [Authorize(Roles = "Member")]
        public IActionResult Index(string profileLink)
        {
            ProfileViewModel pvm = userManager.FindByProfileLink(db, profileLink);
            if (pvm == null)
                return NotFound();
            else
                return View(pvm);
        }

        [Authorize(Roles = "Member")]
        [Route("settings")]
        public async Task<IActionResult> Settings()
        {
            ProfileViewModel pvm = await userManager.GetUserAsync(HttpContext.User);
            return View(pvm);
        }

        [HttpPost]
        [Authorize(Roles = "Member")]
        [Route("settings")]
        public async Task<IActionResult> Settings(string param, string value)
        {
            await userManager.UpdateAsync(UserHelper.Update(param, value, await userManager.GetUserAsync(HttpContext.User)));
            db.SaveChanges();
            return new EmptyResult();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckProfileLink(string profileLink)
        {
            List<string> tabooLinks = new List<string> { "SETTINGS", "USERS" };
            if (db.Users.Count(a => a.ProfileLink == profileLink) > 0 || tabooLinks.Contains(profileLink.ToUpper()))
                return Json(false);
            else
                return Json(true);
        }
    }
}

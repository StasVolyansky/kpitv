using KPITV.Models;
using KPITV.Models.Data;
using KPITV.Models.UsersViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KPITV.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class UsersController : Controller
    {
        ApplicationDbContext db;
        readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        [Route("users")]
        public async Task<IActionResult> Index()
        {
            Dictionary<ApplicationUser, List<string>> usersDict = new Dictionary<ApplicationUser, List<string>>();
            var users = await userManager.GetUsersInRoleAsync("Member");
            foreach (var user in users)
            {
                usersDict.Add(user, await userManager.GetRolesAsync(user) as List<string>);
            }
            return View(new UsersViewModel { Users = usersDict });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string name, string role, bool hasRole)
        {
            if (hasRole)
                await userManager.AddToRoleAsync(await userManager.FindByNameAsync(name), role);
            else
            {
                var lol = await userManager.FindByNameAsync(name);
                await userManager.RemoveFromRoleAsync(await userManager.FindByNameAsync(name), role);
            }
            db.SaveChanges();
            return new EmptyResult();
        }
    }
}

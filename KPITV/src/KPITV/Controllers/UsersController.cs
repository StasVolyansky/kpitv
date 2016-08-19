using KPITV.Models;
using KPITV.Models.UsersViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KPITV.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            Dictionary<ApplicationUser, List<string>> usersDict = new Dictionary<ApplicationUser, List<string>>();
            var users = await userManager.GetUsersInRoleAsync("Researcher");
            foreach (var user in users)
            {
                usersDict.Add(user, await userManager.GetRolesAsync(user) as List<string>);
            }
            return View(new UsersViewModel { Users = usersDict });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string id, string role, bool hasRole)
        {
            if (hasRole)
                await userManager.AddToRoleAsync(await userManager.FindByIdAsync(id), role);
            else
                await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(id), role);
            return View();
        }
    }
}

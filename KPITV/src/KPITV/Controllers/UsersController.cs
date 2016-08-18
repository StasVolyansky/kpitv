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
            var users = await userManager.GetUsersInRoleAsync("user");
            return View(new UsersViewModel { Users = users as List<ApplicationUser> });
        }
    }
}

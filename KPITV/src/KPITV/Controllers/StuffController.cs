using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KPITV.Models.StuffViewModels;
using KPITV.Models;
using KPITV.Models.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using KPITV.Models.BusinessLogic;

namespace KPITV.Controllers
{
    public class StuffController : Controller
    {
        ApplicationDbContext db;
        UserManager<ApplicationUser> userManager;
        IHostingEnvironment hostingEnvironment;

        public StuffController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            this.db = db;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            List<StuffViewModel.Owner> owners = new List<StuffViewModel.Owner>();
            var members = await userManager.GetUsersInRoleAsync("Member") as List<ApplicationUser>;

            foreach (var item in members)
                owners.Add(new StuffViewModel.Owner
                {
                    OwnerName = $"{item.FirstName} {item.LastName}",
                    ImageLink = item.ImageLink,
                    ProfileLink = item.ProfileLink
                });

            var otherOwners = db.Stuff.Select(a => a.OwnerName).Distinct().ToList();

            foreach (var item in otherOwners)
            {
                if (owners.Count(a => a.OwnerName == item) == 0)
                    owners.Add(new StuffViewModel.Owner
                    {
                        OwnerName = item,
                        ImageLink = "images/profile_photos/default.jpg",
                        ProfileLink = ""
                    });
            }
            StuffViewModel svm = new StuffViewModel()
            {
                Types = db.Stuff.Select(a => a.Type).Distinct().ToList(),
                Members = owners
            };
            return View(svm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name, string type, string number, string description, string owner, IFormFile photo)
        {
            Stuff stuff = new Stuff()
            {
                Name = name,
                Type = type,
                Number = number,
                Description = description,
                ImageLink = photo != null ? await StuffHelper.AddPhoto(name, type, photo) : "wwwroot/images/stuff/default.png",
            };
            var user = userManager.FindByProfileLink(db, owner);
            if (user != null)
            {
                stuff.OwnerId = user.Id;
                stuff.OwnerName = $"{user.FirstName} {user.LastName}";
            }
            else
                stuff.OwnerName = owner;
            db.Stuff.Add(stuff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CheckNumber(string number)
        {
            if (db.Stuff.Count(a => a.Number == number) > 0)
                return Json(false);
            else
                return Json(true);
        }

        public IActionResult CheckOwnerName(string name)
        {
            if (db.Users.Count(a => $"{a.FirstName} {a.LastName}" == name) > 0)
                return Json(false);
            else
                return Json(true);
        }
    }
}

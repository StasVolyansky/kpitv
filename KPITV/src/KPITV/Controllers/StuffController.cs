using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KPITV.Models.StuffViewModels;
using KPITV.Models;
using KPITV.Models.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using KPITV.Models.BusinessLogic;
using Microsoft.EntityFrameworkCore;

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

        [Route("[controller]")]
        public IActionResult Index()
        {
            var types = db.Stuff.Select(a => a.Type).ToList().Distinct();
            return View(types);
        }

        [Route("[controller]/{type}")]
        public IActionResult Type(string type)
        {
            var items = db.Stuff.Where(a => a.Type == type).ToList();
            return View(items);
        }

        [Route("[controller]/{type}/{number}")]
        public IActionResult Item(string type, string number)
        {
            var stuffItem = db.Stuff.Where(a => a.Number == number).Include(a => a.Owner).FirstOrDefault();
            return View(stuffItem);
        }

        [Route("[controller]/[action]")]
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
                if (owners.Count(a => a.OwnerName == item) == 0)
                    owners.Add(new StuffViewModel.Owner
                    {
                        OwnerName = item,
                        ImageLink = "images/profile_photos/default.jpg",
                        ProfileLink = ""
                    });
            StuffViewModel svm = new StuffViewModel()
            {
                Types = db.Stuff.Select(a => a.Type).Distinct().ToList(),
                Members = owners
            };
            return View(svm);
        }

        [Route("[controller]/[action]")]
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

        public IActionResult CheckType(string type)
        {
            if (db.Stuff.Count(a => a.Type.ToUpper() == type.ToUpper()) > 0)
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

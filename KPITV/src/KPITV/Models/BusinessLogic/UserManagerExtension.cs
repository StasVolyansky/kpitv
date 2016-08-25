using KPITV.Models.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace KPITV.Models.BusinessLogic
{
    public static class UserManagerExtension
    {
        public static ApplicationUser FindByProfileLink(this UserManager<ApplicationUser> userManager,
            ApplicationDbContext db, string profileLink) =>
            db.Users.Where(a => a.ProfileLink == profileLink).FirstOrDefault();
    }
}
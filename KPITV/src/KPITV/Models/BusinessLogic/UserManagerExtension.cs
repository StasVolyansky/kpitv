using KPITV.Models.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace KPITV.Models.BusinessLogic
{
    public static class UserManagerExtension
    {
        //static UserManagerExtension()
        //{
        //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AzureDbConnection"));
        //db = new ApplicationDbContext(optionsBuilder.Options);
        //}

        public static ApplicationUser FindByProfileLink(this UserManager<ApplicationUser> userManager,
            ApplicationDbContext db, string profileLink) =>
            db.Users.Where(a => a.ProfileLink == profileLink).FirstOrDefault();
    }
}

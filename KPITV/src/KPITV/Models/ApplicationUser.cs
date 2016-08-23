using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KPITV.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string PhoneNumberAdditional { get; set; }
        [MaxLength(50)]
        public string LinkVK { get; set; }
        [MaxLength(70)]
        public string LinkFB { get; set; }
        [MaxLength(140)]
        public string About { get; set; }
        [Required]
        [MaxLength(30)]
        public string ProfileLink { get; set; }
    }
}

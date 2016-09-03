using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KPITV.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public override string UserName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [RegularExpression("[А-ЯЁІЇЄҐ][а-яёіїєґ]+")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [RegularExpression("[А-ЯЁІЇЄҐ][а-яёіїєґ]+")]
        public string LastName { get; set; }
        [MaxLength(20)]
        [Phone]
        [RegularExpression(@"\+380(50|63|66|67|68|73|91|92|93|94|95|96|97|98|99)[0-9]{7}", ErrorMessage = "Invalid phone number format. Example: +380941002929") ]
        public string PhoneNumberAdditional { get; set; }
        [MaxLength(50)]
        public string LinkVK { get; set; }
        [MaxLength(70)]
        public string LinkFB { get; set; }
        [MaxLength(140)]
        public string About { get; set; }
        [Required]
        [RegularExpression("[a-z][a-z0-9]+")]
        [MinLength(3)]
        [MaxLength(30)]
        [Remote(action: "CheckProfileLink", controller: "Profile", ErrorMessage = "This link is occupied \0")]
        public string ProfileLink { get; set; }
    }
}

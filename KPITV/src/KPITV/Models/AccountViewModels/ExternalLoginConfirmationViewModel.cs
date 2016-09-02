using System.ComponentModel.DataAnnotations;

namespace KPITV.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"\+380(50|63|66|67|68|73|91|92|93|94|95|96|97|98|99)[0-9]{7}")]
        public string PhoneNumber { get; set; }
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
        [Required]
        [RegularExpression("[a-z][a-z0-9]+")]
        [MinLength(3)]
        [MaxLength(30)]
        public string ProfileLink { get; set; }
    }
}

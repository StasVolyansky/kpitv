using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KPITV.Models.ProfileViewModels
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberAdditional { get; set; }
        public string LinkVK { get; set; }
        public string LinkFB { get; set; }
        public string About { get; set; }
        public static implicit operator ProfileViewModel(ApplicationUser applicationUser)
        {
            return new ProfileViewModel()
            {
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                PhoneNumber = applicationUser.PhoneNumber,
                Email = applicationUser.Email,
                PhoneNumberAdditional = applicationUser.PhoneNumberAdditional,
                LinkVK = applicationUser.LinkVK,
                LinkFB = applicationUser.LinkFB,
                About = applicationUser.About
            };
        }

    }
}

namespace KPITV.Models.ProfileViewModels
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberAdditional { get; set; }
        public string ProfileLink { get; set; }
        public string LinkVK { get; set; }
        public string LinkFB { get; set; }
        public string About { get; set; }
        public string ImageLink { get; set; }

        public static implicit operator ProfileViewModel(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                return null;
            else
                return new ProfileViewModel()
                {
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    PhoneNumber = applicationUser.PhoneNumber,
                    Email = applicationUser.Email,
                    PhoneNumberAdditional = applicationUser.PhoneNumberAdditional,
                    ProfileLink = applicationUser.ProfileLink,
                    LinkVK = applicationUser.LinkVK,
                    LinkFB = applicationUser.LinkFB,
                    About = applicationUser.About,
                    ImageLink = applicationUser.ImageLink
                };
        }
    }
}

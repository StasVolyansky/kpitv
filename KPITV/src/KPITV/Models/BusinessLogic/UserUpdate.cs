namespace KPITV.Models.BusinessLogic
{
    public static class UserUpdate
    {
        public static ApplicationUser Update(string param, string value, ApplicationUser user)
        {
            switch (param)
            {
                case "email":
                    user.Email = value;
                    break;
                case "firstName":
                    user.FirstName = value;
                    Update("userName", $"{value} {user.LastName}", user);
                    break;
                case "lastName":
                    user.LastName = value;
                    Update("userName", $"{user.FirstName} {value}", user);
                    break;
                case "userName":
                    user.UserName = value;
                    Update("normalizedUserName", value.ToUpper(), user);
                    break;
                case "normalizedUserName":
                    user.NormalizedUserName = value;
                    break;
                case "phoneNumber":
                    user.PhoneNumber = value;
                    break;
                case "phoneNumberAdditional":
                    user.PhoneNumberAdditional = value;
                    break;
                case "profileLink":
                    user.ProfileLink = value;
                    break;
                case "linkVK":
                    user.LinkVK = value;
                    break;
                case "linkFB":
                    user.LinkFB = value;
                    break;
                case "about":
                    user.About = value;
                    break;
            }
            return user;
        }
    }
}

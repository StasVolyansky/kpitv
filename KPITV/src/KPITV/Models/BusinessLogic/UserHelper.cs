using System.Collections.Generic;

namespace KPITV.Models.BusinessLogic
{
    public static class UserHelper
    {
        public static string GetOperator(string phone)
        {
            Dictionary<string, List<string>> Operators = new Dictionary<string, List<string>>{
                { "Lifecell", new List<string> { "93", "63", "73" } },
                { "Vodafone", new List<string> { "50", "66", "95", "99" } },
                { "Kyivstar", new List<string> { "67", "68", "96", "97", "98" } },
            };
            string code = phone.Substring(4, 2);
            foreach (var item in Operators)
                if (item.Value.Contains(code))
                    return item.Key;
            return null;
        }

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

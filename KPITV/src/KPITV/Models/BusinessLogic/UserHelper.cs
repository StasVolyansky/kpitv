using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
                case "imageLink":
                    user.ImageLink = value;
                    break;
            }
            return user;
        }
        public static async Task<string> AddPhoto(ApplicationUser user, IFormFile photo)
        {

            string name = GeneratePhotoName(user);
            string storagePath = $"wwwroot/images/profile_photos/";
            string extension = photo.FileName.Substring(photo.FileName.LastIndexOf('.'));
            string imageLink = $"{storagePath}{name}{extension}";
            using (var fileStream = new FileStream(imageLink, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }
            return imageLink.Substring(8);
        }

        public static string GeneratePhotoName(ApplicationUser user)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(user.Id);
            var CSP = MD5.Create();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string uniquePart = string.Empty;
            foreach (var b in byteHash)
                uniquePart += $"{b:x2}";
            string name = $"{user.FirstName}_{user.LastName}";
            return $"{name}_{uniquePart}";
        }
    }
}

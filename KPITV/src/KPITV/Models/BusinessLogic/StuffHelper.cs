using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KPITV.Models.BusinessLogic
{
    public static class StuffHelper
    {
        public static async Task<string> AddPhoto(string name, string type, IFormFile photo)
        {
            string storagePath = $"wwwroot\\images\\stuff\\{type}";
            string extension = photo.FileName.Substring(photo.FileName.LastIndexOf('.'));
            string imageLink = Path.Combine(storagePath, $"{name}{extension}");
            Directory.CreateDirectory(storagePath);
            using (var fileStream = new FileStream(imageLink, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }
            return storagePath;
        }

    
    }
}

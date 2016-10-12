using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KPITV.Models.StuffViewModels
{
    public class StuffViewModel
    {
        public class Owner
        {
            public string OwnerName { get; set; }
            public string ImageLink { get; set; }
            public string ProfileLink { get; set; }
        }
        [Required]
        [Remote(action: "CheckNumber", controller: "Stuff", ErrorMessage = "This number is occupied")]
        public string Number { get; set; }
        [Required]
        [Remote(action: "CheckType", controller: "Stuff", ErrorMessage = "Oh, this type already exists. Please choose it from the list instead")]
        public string Type { get; set; } // видеокамера, фотоаппарат, объектив, штатив, карта памяти...
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public string OwnerId { get; set; }
        //public ApplicationUser Owner { get; set; }
        [Remote(action: "CheckOwnerName", controller: "Stuff", ErrorMessage = "Oh, this is our member. Please choose it from the list instead")]
        [Required]
        public string OwnerName { get; set; }
        public string ImageLink { get; set; }
        
        public List<string> Types { get; set; }
        public List<Owner> Members { get; set; }
    }
}

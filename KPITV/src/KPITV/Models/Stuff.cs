using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPITV.Models
{
    public class Stuff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Remote(action: "CheckNumber", controller: "Stuff", ErrorMessage = "This number is occupied")]
        public string Number { get; set; }
        public string Type { get; set; } // видеокамера, фотоаппарат, объектив, штатив, карта памяти...
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        [Remote(action: "CheckOwnerName", controller: "Stuff", ErrorMessage = "Oh, this is our member. Please choose it from the list instead")]
        public string OwnerName { get; set; }
        public string ImageLink { get; set; }
    }
}

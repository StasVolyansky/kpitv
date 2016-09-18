using System.Collections.Generic;

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
        public List<string> Types { get; set; }
        public List<Owner> Members { get; set; }
    }
}

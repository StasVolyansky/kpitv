using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPITV.Models.StuffViewModels
{
    public class StuffViewModel
    {
        public List<string> Types { get; set; }
        public List<ApplicationUser> Members { get; set; }
    }
}

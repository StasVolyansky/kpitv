using System.Collections.Generic;

namespace KPITV.Models.UsersViewModels
{
    public class UsersViewModel
    {
        public Dictionary<ApplicationUser, List<string>> Users { get; set; }
    }
}

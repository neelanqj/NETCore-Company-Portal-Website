using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PongStudiosPortal.Models.GenericViewModels
{
    public class EditRoleVm
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}

using BackendFinal.Models;
using Microsoft.AspNetCore.Identity;

namespace BackendFinal.ViewModels
{
    public class RoleChangeVM
    {
        public AppUser User { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}

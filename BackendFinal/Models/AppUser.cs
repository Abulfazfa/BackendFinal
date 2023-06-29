using Microsoft.AspNetCore.Identity;

namespace BackendFinal.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsBlocked { get; set; }
        public string OTP { get; set; }
        public string? ConnectionId { get; set; }
    }
}

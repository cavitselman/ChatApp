using Microsoft.AspNetCore.Identity;

namespace CApp.Authentication
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;
    }
}

using Microsoft.AspNetCore.Identity;

namespace MyShuttle.Model
{
    public class ApplicationUser : IdentityUser
    {
        public int CarrierId { get; set; }
    }
}
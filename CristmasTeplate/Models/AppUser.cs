using Microsoft.AspNetCore.Identity;

namespace CristmasTeplate.Models
{
    public class AppUser : IdentityUser
    {
        public int Age { get; set; }
    }
}

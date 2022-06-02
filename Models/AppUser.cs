using Microsoft.AspNetCore.Identity;

namespace ShoppingCartApp.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}

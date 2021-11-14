using Microsoft.AspNetCore.Identity;

namespace TangoRestaurant.Services.Identity.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

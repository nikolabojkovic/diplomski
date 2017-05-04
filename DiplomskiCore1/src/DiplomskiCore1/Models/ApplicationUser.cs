using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DiplomskiCore1.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string PhotoName { get; set; }

        public string FistName { get; set; }

        public string LastName { get; set; }

        public bool IsCompany { get; set; }

        public string CompanyName { get; set; }

        public bool IsAdmin { get; set; } // feature not implemented yet
    }
}

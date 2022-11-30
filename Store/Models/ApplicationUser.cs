using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}

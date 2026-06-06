using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Services.Models
{
    public class ApplicationUser : IdentityUser
    {
            public string Name { get; set; }
           
    }
}

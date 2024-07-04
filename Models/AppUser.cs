using Microsoft.AspNetCore.Identity;

namespace Travel_Agency_Project.Models {
    public class AppUser:IdentityUser {

        public string? Address { get; set; }

    }
}

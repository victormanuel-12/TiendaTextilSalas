using Microsoft.AspNetCore.Identity;

namespace proyectoTienda.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Dni { get; set; }
        public string? PhoneNumberExtra { get; set; } 
    }
}
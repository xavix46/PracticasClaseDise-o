using Microsoft.AspNetCore.Identity;

namespace Practica_web_api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NombreCompleto { get; set; } = string.Empty;
    }
}

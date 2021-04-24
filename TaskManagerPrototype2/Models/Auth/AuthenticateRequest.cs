using System.ComponentModel.DataAnnotations;

namespace TaskManagerPrototype2.Models.Auth
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
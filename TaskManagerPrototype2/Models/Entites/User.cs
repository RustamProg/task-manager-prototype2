using System.Text.Json.Serialization;

namespace TaskManagerPrototype2.Models.Entites
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; } 
        public Roles Role { get; set; }
    }

    public enum Roles
    {
        Admin,
        DefaultUser
    }
}
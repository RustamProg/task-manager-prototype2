using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerPrototype2.Application.Models.ModelEntities
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
    }
}
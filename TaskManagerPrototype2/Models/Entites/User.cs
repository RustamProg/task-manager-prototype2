namespace TaskManagerPrototype2.Models.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public Roles Role { get; set; }
    }

    public enum Roles
    {
        Admin,
        DefaultUser
    }
}
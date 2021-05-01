namespace TaskManagerPrototype2.Services
{
    public interface ICurrentUser
    {
        int Id { get; set; }
        string Username { get; set; }
    }
}
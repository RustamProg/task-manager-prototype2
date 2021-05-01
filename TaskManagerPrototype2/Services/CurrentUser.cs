namespace TaskManagerPrototype2.Services
{
    public class CurrentUser: ICurrentUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
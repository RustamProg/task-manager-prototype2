using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Models.Auth
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
        }
    }
}
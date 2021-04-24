using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPrototype2.Models.Auth;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        AuthenticateResponse Register(User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
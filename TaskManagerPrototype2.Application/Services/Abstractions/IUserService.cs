using System.Collections.Generic;
using TaskManagerPrototype2.Application.Models.ModelEntities;

namespace TaskManagerPrototype2.Application.Services.Abstractions
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}
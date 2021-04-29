using System.Collections.Generic;
using System.Linq;
using TaskManagerPrototype2.Application.Models;
using TaskManagerPrototype2.Application.Models.ModelEntities;
using TaskManagerPrototype2.Application.Services.Abstractions;

namespace TaskManagerPrototype2.Application.Services
{
    public class UserService: IUserService
    {
        private readonly TasksDbContext _context;

        public UserService(TasksDbContext context)
        {
            _context = context;
        }
        
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
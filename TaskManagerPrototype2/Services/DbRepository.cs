using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerPrototype2.Models;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public class DbRepository: IDbRepository
    {
        private readonly TasksDBContext _context;

        public DbRepository(TasksDBContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User user)
        {
            
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
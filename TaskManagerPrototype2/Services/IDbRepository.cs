using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public interface IDbRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
    }
}
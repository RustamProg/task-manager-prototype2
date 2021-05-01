using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public interface IDbRepository
    {
        Task<int> Add<T>(T entity) where T : BaseEntity;
        IQueryable<T> GetAll<T>() where T : BaseEntity;
        T GetById<T>(int id) where T : BaseEntity;
    }
}
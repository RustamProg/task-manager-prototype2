using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> Add<T>(T entity) where T : BaseEntity
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public IQueryable<T> GetAll<T>() where T : BaseEntity
        {
            var result = _context.Set<T>().AsQueryable();
            return result;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
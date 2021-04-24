using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Models
{
    public class TasksDBContext: DbContext
    {
        public TasksDBContext(DbContextOptions<TasksDBContext> options): base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        
    }
}
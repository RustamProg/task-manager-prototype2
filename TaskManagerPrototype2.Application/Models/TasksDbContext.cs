using Microsoft.EntityFrameworkCore;
using TaskManagerPrototype2.Application.Models.ModelEntities;

namespace TaskManagerPrototype2.Application.Models
{
    public class TasksDbContext: DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options): base(options)
        {
            
        }
        
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
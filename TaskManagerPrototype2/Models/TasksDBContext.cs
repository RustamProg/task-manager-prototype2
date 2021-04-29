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
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
        
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public interface ITasksRepository
    {
        List<Project> GetAllUserProjects(int userId);
        List<TaskNote> GetAllUserTasks(int userId);
        List<TaskComment> GetAllUserTaskComments(int userId);
        List<TaskNote> GetAllTasksByProject(Project project);
        List<TaskComment> GetAllTaskCommentsByTask(TaskNote taskNote);

    }
}
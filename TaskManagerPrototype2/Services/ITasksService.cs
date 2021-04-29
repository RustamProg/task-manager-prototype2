using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public interface ITasksService
    {
        List<Project> GetAllUserProjects(int userId);
        List<TaskNote> GetAllUserTasks(int userId);
        List<TaskComment> GetAllUserTaskComments(int userId);
        List<TaskNote> GetAllTasksByProject(Project project);
        List<TaskComment> GetAllTaskCommentsByTask(TaskNote taskNote);
        Project GetProjectById(int projectId);
        TaskNote GetTaskById(int taskNoteId);
        TaskComment GetTaskCommentById(int taskCommentId);
        Task AddNewProject(Project project);
        Task AddNewTaskNote(TaskNote taskNote);
        Task AddNewTaskComment(TaskComment taskComment);
    }
}
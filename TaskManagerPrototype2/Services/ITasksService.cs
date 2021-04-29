using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPrototype2.FormEntities;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public interface ITasksService
    {
        List<Project> GetAllUserProjects(int userId);
        List<TaskNote> GetAllUserTasks(int userId);
        List<TaskComment> GetAllUserTaskComments(int userId);
        List<TaskNote> GetAllTasksByProject(int projectId);
        List<TaskComment> GetAllTaskCommentsByTask(int taskNoteId);
        Project GetProjectById(int projectId);
        TaskNote GetTaskById(int taskNoteId);
        TaskComment GetTaskCommentById(int taskCommentId);
        Task AddNewProject(ProjectForm projectForm, int userId);
        Task AddNewTaskNote(TaskNoteForm taskNoteForm, int userId);
        Task AddNewTaskComment(TaskCommentForm taskCommentForm, int userId);
    }
}
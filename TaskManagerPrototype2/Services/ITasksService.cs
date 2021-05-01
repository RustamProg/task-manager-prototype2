using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPrototype2.FormEntities;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public interface ITasksService
    {
        List<Project> GetAllUserProjects();
        List<TaskNote> GetAllUserTasks();
        List<TaskComment> GetAllUserTaskComments();
        List<TaskNote> GetAllTasksByProject(int projectId);
        List<TaskComment> GetAllTaskCommentsByTask(int taskNoteId);
        Project GetProjectById(int projectId);
        TaskNote GetTaskById(int taskNoteId);
        TaskComment GetTaskCommentById(int taskCommentId);
        Task AddNewProject(ProjectForm projectForm);
        Task AddNewTaskNote(TaskNoteForm taskNoteForm);
        Task AddNewTaskComment(TaskCommentForm taskCommentForm);
    }
}
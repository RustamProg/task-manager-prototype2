using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagerPrototype2.Models;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TasksDBContext _context;

        public TasksRepository(TasksDBContext context)
        {
            _context = context;
        }

        public List<Project> GetAllUserProjects(int userId)
        {
            return _context.Projects.Include(x => x.Manager).Where(x => x.Manager.Id == userId).ToList();
        }

        public List<TaskNote> GetAllUserTasks(int userId)
        {
            return _context.TaskNotes.Include(x => x.Author).Include(x => x.ProjectRef)
                .Where(x => x.Author.Id == userId).ToList();
        }

        public List<TaskComment> GetAllUserTaskComments(int userId)
        {
            return _context.TaskComments.Include(x => x.Author).Where(x => x.Author.Id == userId).ToList();
        }

        public List<TaskNote> GetAllTasksByProject(Project project)
        {
            return _context.TaskNotes.Include(x => x.Author).Include(x => x.ProjectRef)
                .Where(x => x.ProjectRef.Id == project.Id).ToList();
        }

        public List<TaskComment> GetAllTaskCommentsByTask(TaskNote taskNote)
        {
            return _context.TaskComments.Include(x => x.Author).Where(x => x.TaskNote.Id == taskNote.Id).ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return _context.Projects.Include(x => x.Manager).FirstOrDefault(x => x.Id == projectId);
        }

        public TaskNote GetTaskById(int taskNoteId)
        {
            return _context.TaskNotes.Include(x => x.Author).Include(x => x.ProjectRef)
                .FirstOrDefault(x => x.Id == taskNoteId);
        }

        public TaskComment GetTaskCommentById(int taskCommentId)
        {
            return _context.TaskComments.Include(x => x.Author).FirstOrDefault(x => x.Id == taskCommentId);
        }

        public async Task AddNewProject(Project project)
        {
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewTaskNote(TaskNote taskNote)
        {
            await _context.AddAsync(taskNote);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewTaskComment(TaskComment taskComment)
        {
            await _context.AddAsync(taskComment);
            await _context.SaveChangesAsync();
        }
    }
}
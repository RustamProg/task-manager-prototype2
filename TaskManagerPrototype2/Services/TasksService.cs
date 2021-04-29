using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPrototype2.FormEntities;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.Services
{
    public class TasksService: ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public List<Project> GetAllUserProjects(int userId)
        {
            return _tasksRepository.GetAllUserProjects(userId);
        }

        public List<TaskNote> GetAllUserTasks(int userId)
        {
            return _tasksRepository.GetAllUserTasks(userId);
        }

        public List<TaskComment> GetAllUserTaskComments(int userId)
        {
            return _tasksRepository.GetAllUserTaskComments(userId);
        }

        public List<TaskNote> GetAllTasksByProject(int projectId)
        {
            var project = new Project()
            {
                Id = projectId,
            };
            
            return _tasksRepository.GetAllTasksByProject(project);
        }

        public List<TaskComment> GetAllTaskCommentsByTask(int taskNoteId)
        {
            var taskNote = new TaskNote()
            {
                Id = taskNoteId,
            };

            return _tasksRepository.GetAllTaskCommentsByTask(taskNote);
        }

        public Project GetProjectById(int projectId)
        {
            return _tasksRepository.GetProjectById(projectId);
        }

        public TaskNote GetTaskById(int taskNoteId)
        {
            return _tasksRepository.GetTaskById(taskNoteId);
        }

        public TaskComment GetTaskCommentById(int taskCommentId)
        {
            return _tasksRepository.GetTaskCommentById(taskCommentId);
        }

        public async Task AddNewProject(ProjectForm projectForm, int userId)
        {
            var project = new Project()
            {
                Title = projectForm.Title,
                Description = projectForm.Description,
                CreateDateTime = DateTime.Now,
                TargetDateTime = DateTime.Now,
                Manager = new User(){Id = userId}
            };
            

            await _tasksRepository.AddNewProject(project);
        }

        public async Task AddNewTaskNote(TaskNoteForm taskNoteForm, int userId)
        {
            var taskNote = new TaskNote()
            {
                Title = taskNoteForm.Title,
                TextBody = taskNoteForm.TextBody,
                CreateDateTime = DateTime.Now,
                TargetDateTime = DateTime.Now,
                ProjectRef = new Project() {Id = taskNoteForm.ProjectRefId},
                Author = new User() {Id = userId}
            };

            await _tasksRepository.AddNewTaskNote(taskNote);
        }

        public async Task AddNewTaskComment(TaskCommentForm taskCommentForm, int userId)
        {
            var taskComment = new TaskComment()
            {
                TextBody = taskCommentForm.TextBody,
                TaskNote = new TaskNote() {Id = taskCommentForm.TaskNoteId},
                Author = new User() {Id = userId},
                CreateDateTime = DateTime.Now
            };

            await _tasksRepository.AddNewTaskComment(taskComment);
        }
    }
}
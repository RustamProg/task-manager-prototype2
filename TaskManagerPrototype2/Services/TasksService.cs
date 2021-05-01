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
        private readonly IUserService _userService;
        private readonly IDbRepository _dbRepository;
        private readonly ICurrentUser _currentUser;

        public TasksService(ITasksRepository tasksRepository, IUserService userService, IDbRepository dbRepository, ICurrentUser currentUser)
        {
            _tasksRepository = tasksRepository;
            _userService = userService;
            _dbRepository = dbRepository;
            _currentUser = currentUser;
        }

        public List<Project> GetAllUserProjects()
        {
            return _tasksRepository.GetAllUserProjects(_currentUser.Id);
        }

        public List<TaskNote> GetAllUserTasks()
        {
            return _tasksRepository.GetAllUserTasks(_currentUser.Id);
        }

        public List<TaskComment> GetAllUserTaskComments()
        {
            return _tasksRepository.GetAllUserTaskComments(_currentUser.Id);
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
            return _dbRepository.GetById<Project>(projectId);
        }

        public TaskNote GetTaskById(int taskNoteId)
        {
            return _dbRepository.GetById<TaskNote>(taskNoteId);
        }

        public TaskComment GetTaskCommentById(int taskCommentId)
        {
            return _dbRepository.GetById<TaskComment>(taskCommentId);
        }

        public async Task AddNewProject(ProjectForm projectForm)
        {
            // todo: Use mappers
            var project = new Project
            {
                Title = projectForm.Title,
                Description = projectForm.Description,
                CreateDateTime = DateTime.Now,
                TargetDateTime = DateTime.Now,
                ManagerId = _currentUser.Id
            };


            await _dbRepository.Add(project);
        }

        public async Task AddNewTaskNote(TaskNoteForm taskNoteForm)
        {
            var projectRef = _dbRepository.GetById<Project>(taskNoteForm.ProjectRefId);
            var author = _userService.GetById(_currentUser.Id);
            
            var taskNote = new TaskNote
            {
                Title = taskNoteForm.Title,
                TextBody = taskNoteForm.TextBody,
                ProjectRef = projectRef,
                Author = author
            };

            await _dbRepository.Add(taskNote);
        }

        public async Task AddNewTaskComment(TaskCommentForm taskCommentForm)
        {
            var author = _userService.GetById(_currentUser.Id);
            var taskNote = _dbRepository.GetById<TaskNote>(taskCommentForm.TaskNoteId);
            var taskComment = new TaskComment
            {
                TextBody = taskCommentForm.TextBody,
                TaskNote = taskNote,
                Author = author,
                CreateDateTime = DateTime.Now
            };

            await _dbRepository.Add(taskComment);
        }
    }
}
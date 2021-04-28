using System.Collections.Generic;
using System.Linq;
using TaskManagerPrototype2.Application.Entities;
using TaskManagerPrototype2.Application.Models;
using TaskManagerPrototype2.Application.Models.ModelEntities;
using TaskManagerPrototype2.Application.Services.Abstractions;

namespace TaskManagerPrototype2.Application.Services
{
    public class TaskService: ITaskService
    {
        private readonly TasksDbContext _context;

        public TaskService(TasksDbContext context)
        {
            _context = context;
        }
        
        public void CreateTask(TaskForm taskForm, string username)
        {
            var task = new Task()
            {
                Title = taskForm.Title,
                TextBody = taskForm.TextBody + " (Created by " + username + ")",
                Create_date = taskForm.Create_date
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public List<Task> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public List<Task> GetAllUserTasks(UserInfo userInfo)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTask(TaskForm taskForm)
        {
            throw new System.NotImplementedException();
        }
    }
}
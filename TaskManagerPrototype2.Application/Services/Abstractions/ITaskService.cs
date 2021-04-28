using System.Collections.Generic;
using TaskManagerPrototype2.Application.Entities;
using TaskManagerPrototype2.Application.Models.ModelEntities;

namespace TaskManagerPrototype2.Application.Services.Abstractions
{
    public interface ITaskService
    {
        void CreateTask(TaskForm taskForm, string username);
        List<Task> GetAllTasks();
        List<Task> GetAllUserTasks(UserInfo userInfo);
        void DeleteTask(TaskForm taskForm);
    }
}
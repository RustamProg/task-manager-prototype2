using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPrototype2.Application.Entities;
using TaskManagerPrototype2.Application.Models.ModelEntities;
using TaskManagerPrototype2.Application.Services.Abstractions;

namespace TaskManagerPrototype2.Application.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : Controller
    {

        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Authorize]
        [HttpPost("create-task")]
        public IActionResult CreateTask(TaskForm taskForm)
        {
            _taskService.CreateTask(taskForm, User.FindFirstValue("username"));
            return Ok();
        }
        
        [Authorize]
        [HttpGet("all-tasks")]
        public IActionResult Index()
        {
            return Ok(_taskService.GetAllTasks());
        }
    }
}
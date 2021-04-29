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
        private readonly IUserService _userService;
        public TasksController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        [Authorize]
        [HttpPost("create-task")]
        public IActionResult CreateTask(TaskForm taskForm)
        {
            var user = _userService.GetUserById(int.Parse(User.FindFirstValue("id")));
            _taskService.CreateTask(taskForm, user);
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
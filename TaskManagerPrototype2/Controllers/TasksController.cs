using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPrototype2.FormEntities;
using TaskManagerPrototype2.Services;

namespace TaskManagerPrototype2.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [Authorize]
        [HttpGet("projects")]
        public IActionResult GetProjectsList()
        {
            return Ok(_tasksService.GetAllUserProjects(int.Parse(User.FindFirstValue("id"))));
        }

        [Authorize]
        [HttpPost("create-project")]
        public async Task<IActionResult> CreateProject(ProjectForm projectForm)
        {
            await _tasksService.AddNewProject(projectForm, int.Parse(User.FindFirstValue("id")));
            return Ok();
        }
    }
}
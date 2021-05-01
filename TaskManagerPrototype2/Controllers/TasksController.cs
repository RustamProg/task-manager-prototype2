using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPrototype2.FormEntities;
using TaskManagerPrototype2.Models.Entites;
using TaskManagerPrototype2.Services;

namespace TaskManagerPrototype2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("tasks")]
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }
        
        [HttpGet("projects")]
        public IActionResult GetProjectsList()
        {
            var projects = _tasksService.GetAllUserProjects();
            return projects.Count < 1 ? Ok("Here is no any projects") : Ok(projects);
        }
        
        [HttpGet("tasks")]
        public IActionResult GetTasksList()
        {
            var projects = _tasksService.GetAllUserTasks();
            return projects.Count < 1 ? Ok("Here is no any tasks") : Ok(projects);
        }
        
        [HttpGet("comments")]
        public IActionResult GetCommentsList()
        {
            var projects = _tasksService.GetAllUserTaskComments();
            return projects.Count < 1 ? Ok("Here is no any comments") : Ok(projects);
        }
        
        [HttpPost("create-project")]
        public async Task<IActionResult> CreateProject(ProjectForm projectForm)
        {
            if (projectForm == null)
            {
                return BadRequest("Invalid input params");
            }
            await _tasksService.AddNewProject(projectForm);
            return Ok();
        }
        
        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTask(TaskNoteForm taskNoteForm)
        {
            if (taskNoteForm == null)
            {
                return BadRequest("Invalid input params");
            }

            await _tasksService.AddNewTaskNote(taskNoteForm);
            return Ok();
        }
        
        [HttpPost("create-comment")]
        public async Task<IActionResult> CreateTask(TaskCommentForm taskCommentForm)
        {
            if (taskCommentForm == null)
            {
                return BadRequest("Invalid input params");
            }

            await _tasksService.AddNewTaskComment(taskCommentForm);
            return Ok();
        }
    }
}
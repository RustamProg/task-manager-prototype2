using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPrototype2.Application.Models.ModelEntities;

namespace TaskManagerPrototype2.Application.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : Controller
    {

        
        public TasksController()
        {
            
        }
        
        
        [HttpGet("all-tasks")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
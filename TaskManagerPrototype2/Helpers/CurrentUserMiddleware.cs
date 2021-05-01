using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TaskManagerPrototype2.Services;

namespace TaskManagerPrototype2.Helpers
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context, ICurrentUser currentUser)
        {
            var id = context.User.FindFirstValue("id") ?? "0";
            currentUser.Id = int.Parse(id);
            
            currentUser.Username = context.User.FindFirstValue("username");
            await _next(context);
        }
    }
}
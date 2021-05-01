using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TaskManagerPrototype2.Helpers;
using TaskManagerPrototype2.Models;
using TaskManagerPrototype2.Services;

namespace TaskManagerPrototype2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TasksDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MainConnection")));

            services.AddJwtAuthentication(Configuration);

            services.AddCors(x => x.AddPolicy("DefaultPolicy", policy => policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            
            // Вынесены в extension methods
            services.AddControllers();
            services.AddSwaggerAuthentication();
            
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<ITasksService, TasksService>();

            services.AddScoped<IDbRepository, DbRepository>();
            services.AddScoped<ICurrentUser, CurrentUser>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManagerPrototype2 v1"));
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseCors("DefaultPolicy");
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseMiddleware<JwtMiddleware>();

            app.UseMiddleware<CurrentUserMiddleware>();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
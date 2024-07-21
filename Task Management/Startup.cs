using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task_Management.Interfaces;
using Task_Management.Models;
using Task_Management.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace Task_Management
{
    public class Startup
{
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<TaskManagementContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TaskManagementCon")));

        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<ITaskService, TaskService>();

        services.AddControllers();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

}

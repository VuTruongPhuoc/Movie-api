using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Serilog;
using System.Security.Cryptography.Xml;
using System.Text;

namespace Movie.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add configuration Dbcontext
            builder.Services.AddDbContext<MovieDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieAppDb")));

            //Add serilog to the container
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Logging.AddSerilog();
            //builder.Logging.ClearProviders().AddConsole().AddDebug();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAuthenticationConfiguration(builder.Configuration);
            builder.Services.AddServices();

            // Cors Configuration
            var corsname = "MoviesCORS";
            builder.Services.AddCors(options => options.AddPolicy(corsname, policy =>
            {
                // Allow all origins
                policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
            }));
            builder.Services.AddIdentity<User, Role>(config =>
            {
                config.SignIn.RequireConfirmedEmail = false;
                config.User.RequireUniqueEmail = true;
            })
              .AddEntityFrameworkStores<MovieDbContext>()
              .AddDefaultTokenProviders();

            builder.Services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(corsname);

            app.UseAuthorization();


            app.UseEndpoints(enpoints =>
            {
                enpoints.MapGet("/", () => "Hello World!");
                enpoints.MapGet("api/testenpoints",
                    context => context.Response.WriteAsync(builder.Configuration.GetValue<string>("JWTSecret")));
            });

            app.MapControllers();

            app.Run();
        }
    }
}

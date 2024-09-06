using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Serilog;
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
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddServices();

            // Cors Configuration
            var corsname = "MoviesCORS";
            builder.Services.AddCors(options => options.AddPolicy(corsname, policy =>
            {
                // Allow all origins
                policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
            }));
            // JWT Authentication Configuration
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWTSecret"));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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

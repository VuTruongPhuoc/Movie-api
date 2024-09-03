
using Microsoft.EntityFrameworkCore;
using Movie.API.Data;
using Movie.API.MyLogging;
using Serilog;

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

            //Use this line to ovirride the bulit-in loggers
            builder.Host.UseSerilog();
            //Use serilog alogn with the bulit-in loggers
            builder.Services.AddSerilog();

            //Add Logging to the container
            builder.Logging.ClearProviders().AddConsole().AddDebug();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IMyLogger, LogToDb>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

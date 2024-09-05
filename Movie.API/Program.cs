
using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
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
            //builder.Host.UseSerilog();
            //Use serilog alogn with the bulit-in loggers
            builder.Logging.AddSerilog();

            //Add Logging to the container
            //builder.Logging.ClearProviders().AddConsole().AddDebug();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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

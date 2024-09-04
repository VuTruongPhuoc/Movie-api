using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly ILogger<FilmController> _logger;
        private readonly MovieDbContext _dbContext;

        public FilmController(ILogger<FilmController> logger, MovieDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("All", Name = "GetAllFilms")]
        public ActionResult<Film> GetAllFilms()
        {
            _logger.LogInformation("Start get all films");
            _logger.LogError("Error get all films");
            return Ok(_dbContext.Films.ToList());
        }
    }
}

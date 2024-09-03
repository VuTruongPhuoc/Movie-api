using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Movie.API.MyLogging;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        //private readonly ILogger<FilmController> _logger;

        //public FilmController(ILogger<FilmController> logger)
        //{
        //    _logger = logger;
        //}
        //[HttpGet]
        //public ActionResult Demo()
        //{
        //    _logger.LogInformation("daslfd", );
        //    return Ok();
        
        //}
        private readonly IMyLogger _logger;

        public FilmController(IMyLogger logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Demo()
        {
            _logger.Log("daslfd");
            return Ok();
        }
    }
}

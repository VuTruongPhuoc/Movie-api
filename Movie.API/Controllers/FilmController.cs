﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses.DTOs;

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
        public async Task<ActionResult<IEnumerable<FilmDTO>>> GetFilms()
        {
           
            _logger.LogInformation("Start get all films");
            _logger.LogError("Error get all films");

          /*  var films = _dbContext.Films.Select(x => new FilmDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            }).ToList();*/

            var films = await _dbContext.Films.ToListAsync();
            var filmsdto = CustomMapper.Mapper.Map<List<FilmDTO>>(films);
 
            return Ok(filmsdto);
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetFilmById")]
        [ProducesResponseType(typeof(FilmDTO), 200)]
        public async Task<ActionResult<FilmDTO>> GetFilmById (int id)
        {
            if(id < 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
            var film = await _dbContext.Films.SingleOrDefaultAsync(x => x.Id == id);
           
            if(film == null)
            {
                _logger.LogError("Film not found with given Id");
                return NotFound($"The film with id {id} not found");
            }
            var filmdto = CustomMapper.Mapper.Map<FilmDTO>(film);

            return Ok(filmdto);    
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<FilmDTO>> CreateFilm([FromBody] FilmDTO model)
        {
            if(model == null)
            {
                _logger.LogError("Bad request");
                return BadRequest();
            }

            var film = CustomMapper.Mapper.Map<Film>(model);
            film.NumberOfEpisodes = 40;
            await _dbContext.Films.AddAsync(film);
            await _dbContext.SaveChangesAsync();
            model.Id = film.Id;

            return CreatedAtRoute("GetFilmById", new {id = model.Id}, model);
        }     
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Movie.API.AutoMapper;
using Movie.API.Features.Countries;
using Movie.API.Features.Films;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Requests;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;
using System.Security.Claims;

namespace Movie.API.Controllers
{
    [Route("api/film")]
    [ApiController] 
    public class FilmController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilmController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetFilms()
        {
            var query = new GetFilmsQuery();
            return await _mediator.Send(query);
        }
        [HttpGet("{id}")]
        public async Task<Response> GetFilm(int id)
        {
            var query = new GetFilmQuery();
            query.Id = id;
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddFilm([FromBody] AddFilmRequest model)
        {
            var command = new AddFilmCommand();
            CustomMapper.Mapper.Map<AddFilmRequest, AddFilmCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpPost("update/{id}")]
        public async Task<Response> UpdateFilm(int id, [FromBody] UpdateFilmRequest model)
        {
            var command = new UpdateFilmCommand();
            command.Id = id;
            CustomMapper.Mapper.Map<UpdateFilmRequest, UpdateFilmCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{id}")]
        public async Task<Response> DeleteFilm(int id)
        {
            var command = new DeleteFilmCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}

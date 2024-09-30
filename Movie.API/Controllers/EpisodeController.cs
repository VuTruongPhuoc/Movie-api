using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Episodes;
using Movie.API.Requests;
using Movie.API.Responses;
using Movie.API.Requests.Pagination;

namespace Movie.API.Controllers
{
    [Route("api/episode")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EpisodeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetEpisodes()
        {
            var query = new GetEpisodesQuery() {};
            return await _mediator.Send(query);
        }
        [HttpGet("{filmId}")]
        public async Task<IActionResult> GetEpisodesbyFilm(int filmId)
        {
            var query = new GetEpisodesbyFilmQuery()
            {
                FilmId = filmId,
            };
            var response = await _mediator.Send(query);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddEpisode([FromBody] AddEpisodeRequest model)
        {
            var command = new AddEpisodeCommand();
            CustomMapper.Mapper.Map<AddEpisodeRequest, AddEpisodeCommand>(model, command);
            var response = await _mediator.Send(command);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateEpisode(int id,[FromBody] UpdateEpisodeRequest model)
        {
            var command = new UpdateEpisodeCommand() { Id = id, FilmId = model.FilmId};
            CustomMapper.Mapper.Map<UpdateEpisodeRequest, UpdateEpisodeCommand>(model, command);
            var response = await _mediator.Send(command);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            } else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEpisode(int id)
        {
            var command = new DeleteEpisodeCommand() { Id = id };
            var response =  await _mediator.Send(command);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

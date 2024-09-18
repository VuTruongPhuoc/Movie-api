using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Episodes;
using Movie.API.Requests;
using Movie.API.Responses;

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
            var query = new GetEpisodesQuery();
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddEpisode([FromBody] AddEpisodeRequest model)
        {
            var command = new AddEpisodeCommand();
            CustomMapper.Mapper.Map<AddEpisodeRequest, AddEpisodeCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpPost("update/{id}")]
        public async Task<Response> UpdateEpisode(int id,int filmid, [FromBody] UpdateEpisodeRequest model)
        {
            var command = new UpdateEpisodeCommand();
            command.Id = id;
            command.FilmId = filmid;
            CustomMapper.Mapper.Map<UpdateEpisodeRequest, UpdateEpisodeCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{id}")]
        public async Task<Response> DeleteEpisode(int id)
        {
            var command = new DeleteEpisodeCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}

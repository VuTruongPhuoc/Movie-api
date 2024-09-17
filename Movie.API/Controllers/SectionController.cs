using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Sections;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Controllers
{
    [Route("api/section")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetSections()
        {
            var query = new GetSectionsQuery();
            return await _mediator.Send(query);
        }
        [HttpGet("{id}")]
        public async Task<Response> GetSection(int id)
        {
            var query = new GetSectionQuery();
            query.Id = id;
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddSection([FromBody] AddSectionRequest model)
        {
            var command = new AddSectionCommand();
            CustomMapper.Mapper.Map<AddSectionRequest, AddSectionCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpPost("update/{id}")]
        public async Task<Response> UpdateSection(int id, [FromBody] UpdateSectionRequest model)
        {
            var command = new UpdateSectionCommand();
            command.Id = id;
            CustomMapper.Mapper.Map<UpdateSectionRequest, UpdateSectionCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{id}")]
        public async Task<Response> DeleteSection(int id)
        {
            var command = new DeleteSectionCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Schedules;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetCategories()
        {
            var query = new GetSchedulesQuery();
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddCategory([FromBody] AddScheduleRequest model)
        {
            var command = new AddScheduleCommand();
            command.Name = model.Name;
            return await _mediator.Send(command);
        }
        [HttpPost("update/{id}")]
        public async Task<Response> UpdateCategory(int id, [FromBody] UpdateScheduleRequest model)
        {
            var command = new UpdateScheduleCommand();
            command.Id = id;
            CustomMapper.Mapper.Map<UpdateScheduleRequest, UpdateScheduleCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{id}")]
        public async Task<Response> DeleteCategory(int id)
        {
            var command = new DeleteScheduleCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}

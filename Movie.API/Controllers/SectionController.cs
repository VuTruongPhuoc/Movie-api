using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Sections;
using Movie.API.Requests;
using Movie.API.Requests.Pagination;
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
        public async Task<IActionResult> GetSections()
        {
            var query = new GetSectionsQuery()
            {
            };
            var response = await _mediator.Send(query);
            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSection(int id)
        {
            var query = new GetSectionQuery() { Id = id};
            var response = await _mediator.Send(query);
            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddSection([FromBody] AddSectionRequest model)
        {
            var command = new AddSectionCommand();
            CustomMapper.Mapper.Map<AddSectionRequest, AddSectionCommand>(model, command);
            var response = await _mediator.Send(command);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateSection(int id, [FromBody] UpdateSectionRequest model)
        {
            var command = new UpdateSectionCommand() { Id = id };
            CustomMapper.Mapper.Map<UpdateSectionRequest, UpdateSectionCommand>(model, command);
            var response = await _mediator.Send(command);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var command = new DeleteSectionCommand() { Id = id};         
            var response =  await _mediator.Send(command);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

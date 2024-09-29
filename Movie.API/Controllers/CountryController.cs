using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Features.Countries;
using Movie.API.Requests;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;

namespace Movie.API.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetCountries()
        {
            var query = new GetCountriesQuery() { };
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCountry([FromBody] AddCountryRequest model)
        {
            var command = new AddCountryCommand() { Name = model.Name};
            var response =  await _mediator.Send(command);
            if(response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountryRequest model)
        {
            var command = new UpdateCountryCommand() { Id = id};
            CustomMapper.Mapper.Map<UpdateCountryRequest, UpdateCountryCommand>(model, command);
            var response = await _mediator.Send(command);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            } else if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var command = new DeleteCountryCommand() { Id = id};
            var response = await _mediator.Send(command);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

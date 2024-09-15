using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Features.Countries;
using Movie.API.Requests;
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
            var query = new GetCountriesQuery();
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddCountry([FromBody] AddCountryRequest model)
        {
            var command = new AddCountryCommand();
            command.Name = model.Name;
            return await _mediator.Send(command);
        }
        [HttpPost("update/{id}")]
        public async Task<Response> UpdateCountry(int id, [FromBody] UpdateCountryRequest model)
        {
            var command = new UpdateCountryCommand();
            command.Id = id;
            CustomMapper.Mapper.Map<UpdateCountryRequest, UpdateCountryCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{id}")]
        public async Task<Response> DeleteCountry(int id)
        {
            var command = new DeleteCountryCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}

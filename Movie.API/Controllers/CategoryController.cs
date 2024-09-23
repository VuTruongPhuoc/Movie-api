using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Features.Countries;
using Movie.API.Requests;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;
using System.Net;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetCategories(int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetCategoriesQuery()
            {
                Pagination = new Pagination() { pageNumber = pageNumber, pageSize = pageSize }
            };
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest model)
        {
            var command = new AddCategoryCommand { Name = model.Name };
            var result = await _mediator.Send(command);
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id,[FromBody] UpdateCategoryRequest model)
        {
            var command = new UpdateCategoryCommand() { Id = id};
            CustomMapper.Mapper.Map<UpdateCategoryRequest, UpdateCategoryCommand>(model,command);
            var result = await _mediator.Send(command); 
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            } else if(result.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand() { Id = id };
            var result = await _mediator.Send(command);
            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}

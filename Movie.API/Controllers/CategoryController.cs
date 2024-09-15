using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Features.Countries;
using Movie.API.Requests;
using Movie.API.Responses;

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
        public async Task<Response> GetCategories()
        {
            var query = new GetCategoriesQuery();
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddCategory([FromBody] AddCategoryRequest model)
        {
            var command = new AddCategoryCommand();
            command.Name = model.Name;
            return await _mediator.Send(command);
        }
        [HttpPost("update/{id}")]
        public async Task<Response> UpdateCategory(int id,[FromBody] UpdateCategoryRequest model)
        {
            var command = new UpdateCategoryCommand();
            command.Id = id;
            CustomMapper.Mapper.Map<UpdateCategoryRequest, UpdateCategoryCommand>(model,command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{id}")]
        public async Task<Response> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }

    }
}

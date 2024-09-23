using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Features.Comments;
using Movie.API.Requests;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;
using System.Net;
using System.Security.Claims;

namespace Movie.API.Controllers
{
    [Route("api/comment")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetCommnets(int pageNumber = 1, int pageSize = 10, int filmid = 1)
        {        
            var query = new GetCommentsQuery() 
            { 
                FilmId = filmid,
                Pagination =  new Pagination()
                { 
                    pageNumber = pageNumber, 
                    pageSize = pageSize
                }
            };
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddComment([FromBody] AddCommentRequest model)
        {
            string userid = HttpContext.User.FindFirstValue("UserId");
            var command = new AddCommentCommand() { UserId = userid};
            CustomMapper.Mapper.Map<AddCommentRequest, AddCommentCommand>(model, command);

            var response = await _mediator.Send(command);
            if(response.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] UpdateCommentRequest model)
        {
            var command = new UpdateCommentCommand() { Id = id};
            CustomMapper.Mapper.Map<UpdateCommentRequest, UpdateCommentCommand>(model, command);
            var response = await _mediator.Send(command);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response);
            }
            else if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var command = new DeleteCommentCommand() { Id = id};
            var response = await _mediator.Send(command);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

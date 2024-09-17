using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Features.Comments;
using Movie.API.Requests;
using Movie.API.Responses;
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
        public async Task<Response> GetCommnets(int filmid)
        {        
            var query = new GetCommentsQuery();
            query.FilmId = filmid;
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddComment([FromBody] AddCommentRequest model)
        {
            string userid = HttpContext.User.FindFirstValue("UserId");
            var command = new AddCommentCommand();
            command.UserId = userid;
            CustomMapper.Mapper.Map<AddCommentRequest, AddCommentCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpPost("update/{id}")]
        public async Task<Response> UpdateComment(int id, [FromBody] UpdateCommentRequest model)
        {
            var command = new UpdateCommentCommand();
            command.Id = id;
            CustomMapper.Mapper.Map<UpdateCommentRequest, UpdateCommentCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{id}")]
        public async Task<Response> DeleteComment(int id)
        {
            var command = new DeleteCommentCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}

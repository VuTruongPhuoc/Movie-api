using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Reviews;
using Movie.API.Requests;
using Movie.API.Responses;
using Movie.API.Requests.Pagination;
using System.Security.Claims;

namespace Movie.API.Controllers
{
    [Route("api/review")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetReviews(int pageNumber = 1, int pageSize = 10, int filmid = 1)
        {
            var query = new GetReviewsQuery()
            {
                FilmId = filmid,
                Pagination = new Pagination()
                {
                    pageNumber = pageNumber,
                    pageSize = pageSize
                }
            };
            return await _mediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddReview([FromBody] AddReviewRequest model)
        {
            string userid = HttpContext.User.FindFirstValue("UserId");
            var command = new AddReviewCommand();
            command.UserId = userid;
            CustomMapper.Mapper.Map<AddReviewRequest, AddReviewCommand>(model, command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{id}")]
        public async Task<Response> DeleteReview(int id)
        {
            var command = new DeleteReviewCommand();
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}

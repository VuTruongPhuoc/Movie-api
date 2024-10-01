using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Feedbacks;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Feedbacks
{
    public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksQuery, Response>
    {
        private readonly MovieDbContext _dbContext;
        private IFeedbackRepository _feedbackRepository;

        public GetFeedbacksQueryHandler(MovieDbContext dbContext, IFeedbackRepository feedbackRepository)
        {
            _dbContext = dbContext;
            _feedbackRepository = feedbackRepository;
        }
        public async Task<Response> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackRepository.GetAllAsync(request.CommentId);

            var dtos = CustomMapper.Mapper.Map<List<FeedbackDTO>>(feedbacks);

            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = dtos
            });
        }
    }
}

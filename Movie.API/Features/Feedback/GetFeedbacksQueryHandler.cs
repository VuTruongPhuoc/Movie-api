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

            var feedbackDtos = new List<FeedbackDTO>();

            foreach (var feedback in feedbacks)
            {
                var dto = CustomMapper.Mapper.Map<FeedbackDTO>(feedback);
                dto.User = CustomMapper.Mapper.Map<UserDTO>(await _dbContext.Users.FindAsync(feedback.UserId));
                feedbackDtos.Add(dto);
            }


            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = feedbackDtos
            });
        }
    }
}

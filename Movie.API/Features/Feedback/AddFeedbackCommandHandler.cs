using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Feedbacks
{
    public class AddFeedbackCommandHandler : IRequestHandler<AddFeedbackCommand, AddFeedbackResponse>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly MovieDbContext _dbContext;
        public AddFeedbackCommandHandler(IFeedbackRepository feedbackRepository, MovieDbContext dbContext)
        {
            _feedbackRepository = feedbackRepository;
            _dbContext = dbContext;
        }

        public async Task<AddFeedbackResponse> Handle(AddFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = CustomMapper.Mapper.Map<Feedback>(request);
            feedback.CreateDate = DateTime.UtcNow;
            await _feedbackRepository.AddAsync(feedback);
            await _feedbackRepository.SaveAsync();

            var dto = CustomMapper.Mapper.Map<FeedbackDTO>(feedback);
            dto.User = CustomMapper.Mapper.Map<UserDTO>(await _dbContext.Users.FindAsync(feedback.UserId));

            return await Task.FromResult(new AddFeedbackResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Bình luận thành công",
                Feedback = CustomMapper.Mapper.Map<FeedbackDTO>(feedback)
            });
        }
    }
}

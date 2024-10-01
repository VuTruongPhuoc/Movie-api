using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Feedbacks
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, Response>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly MovieDbContext _dbContext;
        public DeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository, MovieDbContext dbContext)
        {
            _feedbackRepository = feedbackRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return await Task.FromResult(new DeleteFeedbackResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy feedback cần xóa"
                });
            }
            var feedback = await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            await _feedbackRepository.DeleteAsync(request.Id);
            await _feedbackRepository.SaveAsync();
            return await Task.FromResult(new DeleteFeedbackResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa bình luận thành công",
                Feedback = CustomMapper.Mapper.Map<FeedbackDTO>(feedback)
            });

        }
    }
}

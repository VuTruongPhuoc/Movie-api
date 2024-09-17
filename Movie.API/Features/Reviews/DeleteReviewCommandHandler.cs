using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Reviews;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Reviews
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Response>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly MovieDbContext _dbContext;
        public DeleteReviewCommandHandler(IReviewRepository reviewRepository, MovieDbContext dbContext)
        {
            _reviewRepository = reviewRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return await Task.FromResult(new DeleteReviewResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy đánh giá cần xóa"
                });
            }
            var review = await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            await _reviewRepository.DeleteAsync(request.Id);
            await _reviewRepository.SaveAsync();
            return await Task.FromResult(new DeleteReviewResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa đánh giá thành công",
                Review = CustomMapper.Mapper.Map<ReviewDTO>(review)
            });

        }
    }
}

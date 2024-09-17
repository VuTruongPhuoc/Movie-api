using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Features.Reviews;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Reviews
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, Response>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly MovieDbContext _dbContext;
        public AddReviewCommandHandler(IReviewRepository reviewRepository, MovieDbContext dbContext)
        {
            _reviewRepository = reviewRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = CustomMapper.Mapper.Map<Review>(request);
            review.CreateDate = DateTime.UtcNow;
            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveAsync();
            return await Task.FromResult(new AddReviewResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Đánh giá thành công",
                Review = CustomMapper.Mapper.Map<ReviewDTO>(review)
            });
        }
    }
}

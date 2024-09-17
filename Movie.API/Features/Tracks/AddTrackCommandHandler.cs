using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Features.Tracks;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Tracks
{
    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, Response>
    {
        private readonly ITrackRepository _reviewRepository;
        private readonly MovieDbContext _dbContext;
        public AddTrackCommandHandler(ITrackRepository reviewRepository, MovieDbContext dbContext)
        {
            _reviewRepository = reviewRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            var review = CustomMapper.Mapper.Map<Track>(request);
            review.CreateDate = DateTime.UtcNow;
            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveAsync();
            return await Task.FromResult(new AddTrackResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Đánh giá thành công",
                Track = CustomMapper.Mapper.Map<TrackDTO>(review)
            });
        }
    }
}

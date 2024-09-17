using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Tracks;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Tracks
{
    public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand, Response>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly MovieDbContext _dbContext;
        public DeleteTrackCommandHandler(ITrackRepository trackRepository, MovieDbContext dbContext)
        {
            _trackRepository = trackRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return await Task.FromResult(new DeleteTrackResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy đánh giá cần xóa"
                });
            }
            var track = await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            await _trackRepository.DeleteAsync(request.Id);
            await _trackRepository.SaveAsync();
            return await Task.FromResult(new DeleteTrackResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa đánh giá thành công",
                Track = CustomMapper.Mapper.Map<TrackDTO>(track)
            });

        }
    }
}

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
    public class GetTracksQueryHandler : IRequestHandler<GetTracksQuery, Response>
    {
        private readonly MovieDbContext _dbContext;

        public GetTracksQueryHandler(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Tracks.Where(x => x.UserId == request.UserId).ToListAsync();

            var dtos = CustomMapper.Mapper.Map<List<TrackDTO>>(comments);

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

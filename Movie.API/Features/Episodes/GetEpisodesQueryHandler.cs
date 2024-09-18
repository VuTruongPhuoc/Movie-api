using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Episodes;
using Movie.API.Infrastructure.Data;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Episodes
{
    public class GetEpisodesQueryHandler : IRequestHandler<GetEpisodesQuery, Response>
    {
        private readonly MovieDbContext _dbContext;

        public GetEpisodesQueryHandler(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(GetEpisodesQuery request, CancellationToken cancellationToken)
        {
            var episodes = await _dbContext.Episodes.Where(x => x.FilmId == request.FilmId).ToListAsync();

            var dtos = CustomMapper.Mapper.Map<List<EpisodeDTO>>(episodes);

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

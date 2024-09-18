using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Episodes;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Episodes
{
    public class DeleteEpisodeCommandHandler : IRequestHandler<DeleteEpisodeCommand, Response>
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly MovieDbContext _dbContext;
        public DeleteEpisodeCommandHandler(IEpisodeRepository EpisodeRepository, MovieDbContext dbContext)
        {
            _episodeRepository = EpisodeRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(DeleteEpisodeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return await Task.FromResult(new DeleteEpisodeResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy tập cần xóa"
                });
            }
            var Episode = await _dbContext.Episodes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            await _episodeRepository.DeleteAsync(request.Id);
            await _episodeRepository.SaveAsync();
            return await Task.FromResult(new DeleteEpisodeResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa tập thành công",
                Episode = CustomMapper.Mapper.Map<EpisodeDTO>(Episode)
            });

        }
    }
}

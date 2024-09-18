using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Episodes;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Episodes
{
    public class AddEpisodeCommandHandler : IRequestHandler<AddEpisodeCommand, Response>
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly MovieDbContext _dbContext;
        public AddEpisodeCommandHandler(IEpisodeRepository episodeRepository, MovieDbContext dbContext)
        {
            _episodeRepository = episodeRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddEpisodeCommand request, CancellationToken cancellationToken)
        {
            var episode = CustomMapper.Mapper.Map<Episode>(request);
            var episodeExists = await _dbContext.Episodes.SingleOrDefaultAsync(x => x.Name == episode.Name && x.FilmId == request.FilmId);
            if (episodeExists != null)
            {
                return await Task.FromResult(new AddEpisodeResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Tập này đã tồn tại",
                });
            }
            episode.CreateDate = DateTime.UtcNow;
            await _episodeRepository.AddAsync(episode);
            await _episodeRepository.SaveAsync();
            return await Task.FromResult(new AddEpisodeResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm tập thành công",
                Episode = CustomMapper.Mapper.Map<EpisodeDTO>(episode)
            });
        }
    }
}

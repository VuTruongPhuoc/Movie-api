using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Episodes;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Episodes
{
    public class GetEpisodesQueryHandler : IRequestHandler<GetEpisodesQuery, Response>
    {
        private readonly IEpisodeRepository _episodeRepository;

        public GetEpisodesQueryHandler(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }
        public async Task<Response> Handle(GetEpisodesQuery request, CancellationToken cancellationToken)
        {
            var episodes = await _episodeRepository.GetAllAsync(request.Pagination.pageNumber, request.Pagination.pageNumber, request.FilmId);

            var dtos = CustomMapper.Mapper.Map<PaginatedList<EpisodeDTO>>(episodes);

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

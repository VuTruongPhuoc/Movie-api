using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses.DTOs;
using Movie.API.Responses;
using Movie.API.Features.Episodes;

namespace Movie.API.Features.EpisodesbyFilm
{
    public class GetEpisodesbyFilmQueryHandler : IRequestHandler<GetEpisodesbyFilmQuery, Response>
    {
        private readonly IEpisodeRepository _episodeRepository;

        public GetEpisodesbyFilmQueryHandler(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }
        public async Task<Response> Handle(GetEpisodesbyFilmQuery request, CancellationToken cancellationToken)
        {
            var episodes = await _episodeRepository.GetEpisodesByFilm(request.FilmId);
            if(episodes is null || !episodes.Any())
            {
                return await Task.FromResult(new Response()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy"
                });
            }

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

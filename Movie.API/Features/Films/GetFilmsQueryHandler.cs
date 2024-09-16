using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Features.Countries;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Films
{
    public class GetFilmsQueryHandler : IRequestHandler<GetFilmsQuery, Response>
    {
        private IFilmRepository _FilmRepository;

        public GetFilmsQueryHandler(IFilmRepository FilmRepository)
        {
            _FilmRepository = FilmRepository;
        }
        public async Task<Response> Handle(GetFilmsQuery request, CancellationToken cancellationToken)
        {
            var films = await _FilmRepository.GetAllAsync();

            var dtos = CustomMapper.Mapper.Map<List<FilmDTO>>(films);

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

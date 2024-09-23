using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Features.Countries;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Films
{
    public class GetFilmsQueryHandler : IRequestHandler<GetFilmsQuery, Response>
    {
        private IFilmRepository _filmRepository;

        public GetFilmsQueryHandler(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }
        public async Task<Response> Handle(GetFilmsQuery request, CancellationToken cancellationToken)
        {
            var films = await _filmRepository.GetAllAsync(request.Pagination.pageNumber, request.Pagination.pageSize);

            var dtoFilms = CustomMapper.Mapper.Map<PaginatedList<FilmDTO>>(films);
            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = dtoFilms
            });
        }
    }
}

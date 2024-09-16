using Movie.API.AutoMapper;
using Movie.API.Features.Countries;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses.DTOs;
using Movie.API.Responses;
using MediatR;

namespace Movie.API.Features.Films
{
    public class GetFilmQueryHandler : IRequestHandler<GetFilmQuery, Response>
    {
        private IFilmRepository _filmRepository;

        public GetFilmQueryHandler(IFilmRepository FilmRepository)
        {
            _filmRepository = FilmRepository;
        }
        public async Task<Response> Handle(GetFilmQuery request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return await Task.FromResult(new Response()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Yêu cầu trống",

                });
            }
            var film = await _filmRepository.GetByIdAsync(request.Id);
            if(film is null )
            {
                return await Task.FromResult(new Response()
                {
                    Success = false,
                    StatusCode= System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy phim"
                });
            }
            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = CustomMapper.Mapper.Map<FilmDTO>(film)

            }) ;
        }
    }
}

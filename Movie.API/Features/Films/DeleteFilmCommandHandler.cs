using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Countries;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Films
{
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, Response>
    {
        private readonly IFilmRepository _FilmRepository;
        private readonly MovieDbContext _dbContext;
        public DeleteFilmCommandHandler(IFilmRepository FilmRepository, MovieDbContext dbContext)
        {
            _FilmRepository = FilmRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                return await Task.FromResult(new DeleteFilmResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy Film cần xóa"
                });
            }
            var Film = await _dbContext.Films.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            await _FilmRepository.DeleteAsync(request.Id);
            await _FilmRepository.SaveAsync();
            return await Task.FromResult(new DeleteFilmResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa Film thành công",
                Film = CustomMapper.Mapper.Map<FilmDTO>(Film)
            });

        }
    }
}

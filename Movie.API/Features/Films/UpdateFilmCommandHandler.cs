using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Films;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Films
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand, Response>
    {
        private readonly IFilmRepository _FilmRepository;
        private readonly MovieDbContext _dbContext;
        public UpdateFilmCommandHandler(IFilmRepository FilmRepository, MovieDbContext dbContext)
        {
            _FilmRepository = FilmRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                return await Task.FromResult(new UpdateFilmResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy lịch cần cập nhật",
                });
            }
            var Film = await _dbContext.Films.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            var FilmName = await _dbContext.Films.AsNoTracking().SingleOrDefaultAsync(x => x.Name == request.Name);
            if (FilmName?.Name != Film?.Name && FilmName != null)
            {
                return await Task.FromResult(new UpdateFilmResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Lịch đã tồn tại",
                });
            }
            CustomMapper.Mapper.Map<UpdateFilmCommand, Film>(request, Film);
            Film.LastModifiedDate = DateTime.UtcNow;
            await _FilmRepository.UpdateAsync(Film);
            await _FilmRepository.SaveAsync();
            return await Task.FromResult(new UpdateFilmResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Cập nhật lịch thành công",
                Film = CustomMapper.Mapper.Map<FilmDTO>(Film)
            });
        }
    }
}

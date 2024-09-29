using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Films
{
    public class AddFilmCommandHandler : IRequestHandler<AddFilmCommand, Response>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly MovieDbContext _dbContext;
        public AddFilmCommandHandler(IFilmRepository filmRepository, MovieDbContext dbContext)
        {
            _filmRepository = filmRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddFilmCommand request, CancellationToken cancellationToken)
        {
            var film = CustomMapper.Mapper.Map<Film>(request);
            var filmExists = await _dbContext.Films.SingleOrDefaultAsync(x => x.Name == film.Name);
            if (filmExists != null)
            {
                return await Task.FromResult(new AddFilmResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Phim đã tồn tại",
                });
            }
            film.CreateDate = DateTime.UtcNow;
            await _filmRepository.AddAsync(film);
            await _filmRepository.SaveAsync();

            foreach(var categoryId in request.CategoryIds)
            {
                await _dbContext.FilmCategories.AddAsync(new FilmCategory
                {
                    FilmId = film.Id,
                    CategoryId = categoryId,
                });
            }
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new AddFilmResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm phim thành công",
                Film = CustomMapper.Mapper.Map<FilmDTO>(film)
            });
        }

    }
}

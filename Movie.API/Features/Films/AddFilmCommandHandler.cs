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
            var country = CustomMapper.Mapper.Map<Film>(request);
            var countryExists = await _dbContext.Countries.SingleOrDefaultAsync(x => x.Name == country.Name);
            if (countryExists != null)
            {
                return await Task.FromResult(new AddFilmResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Quốc gia đã tồn tại",
                });
            }
            country.CreateDate = DateTime.UtcNow;
            await _filmRepository.AddAsync(country);
            await _filmRepository.SaveAsync();
            return await Task.FromResult(new AddFilmResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm quốc gia thành công",
                Film = CustomMapper.Mapper.Map<FilmDTO>(country)
            });
        }

    }
}

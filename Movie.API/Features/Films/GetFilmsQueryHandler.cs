using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Countries;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Films
{
    public class GetFilmsQueryHandler : IRequestHandler<GetFilmsQuery, DataRespone>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly MovieDbContext _dbContext;

        public GetFilmsQueryHandler(
            IFilmRepository filmRepository, 
            ICountryRepository countryRepository, 
            IScheduleRepository scheduleRepository,
            MovieDbContext dbContext)
            {
                _filmRepository = filmRepository;
                _countryRepository = countryRepository;
                _scheduleRepository = scheduleRepository;
                _dbContext = dbContext;
           
            }
        public async Task<DataRespone> Handle(GetFilmsQuery request, CancellationToken cancellationToken)
        {
            /*var films = await _filmRepository.GetAllAsync();
            var filmDtos = new List<FilmDTO>();
            foreach (var film in films)
            {
                var scheduleid = film.ScheduleId;
                var countryid = film.CountryId;
                var filmcategories = await _dbContext.FilmCategories.Where(x => x.FilmId == film.Id).ToListAsync();
                var dto = CustomMapper.Mapper.Map<FilmDTO>(film);
                foreach (var filmcategory in filmcategories)
                {
                    dto.Categories.Add(CustomMapper.Mapper.Map<CategoryDTO>(await _dbContext.Categories.SingleOrDefaultAsync(x => x.Id == filmcategory.CategoryId)));
                }
                dto.Schedule = CustomMapper.Mapper.Map<ScheduleDTO>(await _scheduleRepository.GetByIdAsync(scheduleid));
                dto.Country = CustomMapper.Mapper.Map<CountryDTO>(await _countryRepository.GetByIdAsync(countryid));
                filmDtos.Add(dto);
            }*/
            var films = await _dbContext.Films
                .Include(f => f.FilmCategories)
                    .ThenInclude(fc => fc.Category)
                .Include(f => f.Schedule)
                .Include(f => f.Country)
                .ToListAsync();

            var filmDtos = films.Select(film =>
            {
                var dto = CustomMapper.Mapper.Map<FilmDTO>(film);
                dto.Categories = film.FilmCategories
                    .Select(fc => CustomMapper.Mapper.Map<CategoryDTO>(fc.Category))
                    .ToList();
                dto.Schedule = CustomMapper.Mapper.Map<ScheduleDTO>(film.Schedule);
                dto.Country = CustomMapper.Mapper.Map<CountryDTO>(film.Country);
                return dto;
            }).ToList();

            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = filmDtos
            });
        }
    }
}

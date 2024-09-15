using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Countries
{
    public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, Response>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly MovieDbContext _dbContext;
        public AddCountryCommandHandler(ICountryRepository countryRepository, MovieDbContext dbContext)
        {
            _countryRepository = countryRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            var country = CustomMapper.Mapper.Map<Country>(request);
            var countryExists = await _dbContext.Countries.SingleOrDefaultAsync(x => x.Name == country.Name);
            if (countryExists != null)
            {
                return await Task.FromResult(new AddCountryResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Quốc gia đã tồn tại",
                });
            }
            country.CreateDate = DateTime.UtcNow;
            await _countryRepository.AddAsync(country);
            await _countryRepository.SaveAsync();
            return await Task.FromResult(new AddCountryResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm quốc gia thành công",
                Country = CustomMapper.Mapper.Map<CountryDTO>(country)
            });
        }
    }
}

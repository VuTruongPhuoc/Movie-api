using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Countries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, Response>
    {
        private ICountryRepository _countryRepository;
       
        public GetCountriesQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        } 
        public async Task<Response> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetAllAsync();

            var dtos = CustomMapper.Mapper.Map<List<CountryDTO>>(countries);

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

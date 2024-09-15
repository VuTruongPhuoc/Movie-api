using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class CountryResponse
    {
    }
    public class GetCountriesResponse : Response
    {
        public List<CountryDTO> Countries { get; set; }
    }
    public class AddCountryResponse : Response
    {
        public CountryDTO Country { get; set; }
    }
    public class UpdateCountryResponse : Response
    {
        public CountryDTO Country { get; set; }
    }
    public class DeleteCountryResponse : Response
    {
        public CountryDTO Country { get; set; }
    }
}

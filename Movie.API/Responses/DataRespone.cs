using System.Text.Json.Serialization;

namespace Movie.API.Responses
{
    public class DataRespone : Respone
    {
        [JsonPropertyOrder(1)]
        public dynamic Data { get; set; }
    }
}

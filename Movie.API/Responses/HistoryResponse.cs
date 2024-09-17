using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class GetHistoriesResponse : Response
    {
        public List<HistoryDTO> Histories { get; set; }
    }
    public class AddHistoryResponse : Response
    {
        public HistoryDTO History { get; set; }
    }
    public class DeleteHistoryResponse : Response
    {
        public HistoryDTO History { get; set; }
    }
}

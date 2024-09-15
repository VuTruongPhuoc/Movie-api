using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class ScheduleResponse
    {
    }
    public class GetSchedulesResponse : Response
    {
        public List<ScheduleDTO> Schedules { get; set; }
    }
    public class AddScheduleResponse : Response
    {
        public ScheduleDTO Schedule { get; set; }
    }
    public class UpdateScheduleResponse : Response
    {
        public ScheduleDTO Schedule { get; set; }
    }
    public class DeleteScheduleResponse : Response
    {
        public ScheduleDTO Schedule { get; set; }
    }
}

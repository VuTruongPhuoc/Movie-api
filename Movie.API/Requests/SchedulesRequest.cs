namespace Movie.API.Requests
{
    public class SchedulesRequest
    {
    }
    public class AddScheduleRequest
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class UpdateScheduleRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
    public class DeleteScheduleRequest
    {

    }
}

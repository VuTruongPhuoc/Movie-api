namespace Movie.API.Requests
{
    public class AddSectionRequest
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class UpdateSectionRequest
    {
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
    public class DeleteSectionRequest
    {

    }
}

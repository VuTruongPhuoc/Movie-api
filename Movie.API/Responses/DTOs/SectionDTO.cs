namespace Movie.API.Responses.DTOs
{
    public class SectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

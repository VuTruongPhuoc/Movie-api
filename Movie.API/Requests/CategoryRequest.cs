namespace Movie.API.Requests
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class UpdateCategoryRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
    public class DeleteCategoryRequest
    {
        
    }
}

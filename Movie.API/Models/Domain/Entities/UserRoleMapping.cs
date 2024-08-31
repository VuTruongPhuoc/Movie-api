namespace Movie.API.Models.Domain.Entities
{
    public class UserRoleMapping
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}

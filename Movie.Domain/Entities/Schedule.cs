using Movie.Domain.Common;


namespace Movie.Domain.Entities
{
    public class Schedule : BaseDomainEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}

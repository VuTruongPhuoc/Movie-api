using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class GetSectionsResponse : Response
    {
        public List<SectionDTO> Sections { get; set; }
    }
    public class AddSectionResponse : Response
    {
        public SectionDTO Section { get; set; }
    }
    public class UpdateSectionResponse : Response
    {
        public SectionDTO Section { get; set; }
    }
    public class DeleteSectionResponse : Response
    {
        public SectionDTO Section { get; set; }
    }
}

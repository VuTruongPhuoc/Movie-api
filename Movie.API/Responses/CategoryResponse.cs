using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class GetCategoriesResponse : Response
    {
        public List<CategoryDTO> Categories { get; set; }
    }
    public class AddCategoryResponse : Response
    {
        public CategoryDTO Category { get; set; }
    }
    public class UpdateCategoryResponse : Response
    {
        public CategoryDTO Category { get; set;}
    }
    public class DeleteCategoryResponse : Response
    {
        public CategoryDTO Category { get; set;}
    }
}

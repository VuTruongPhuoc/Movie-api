using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Categories
{
    public class AddCategoryCommand : AddCategoryRequest, IRequest<Response>
    {
    }
}

using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Categories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Response>
    {
        private ICategoryRepository _categoryRepository;
       
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        } 
        public async Task<Response> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            var dtos = CustomMapper.Mapper.Map<List<CategoryDTO>>(categories);

            return await Task.FromResult(new GetCategoriesResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Categories = dtos
            });
        }
    }
}

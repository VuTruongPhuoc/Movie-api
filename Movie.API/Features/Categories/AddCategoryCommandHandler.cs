using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Categories
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Response>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly MovieDbContext _dbContext;
        public AddCategoryCommandHandler(ICategoryRepository categoryRepository, MovieDbContext dbContext)
        {
            _categoryRepository = categoryRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = CustomMapper.Mapper.Map<Category>(request);
            var categoryExists = await _dbContext.Categories.SingleOrDefaultAsync(x => x.Name == category.Name);
            if (categoryExists != null)
            {
                return await Task.FromResult(new AddCategoryResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Thể loại đã tồn tại",
                });
            }
            category.CreateDate = DateTime.UtcNow;
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            return await Task.FromResult(new AddCategoryResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm thể loại thành công",
                Category = CustomMapper.Mapper.Map<CategoryDTO>(category)
            });
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Sections;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Sections
{
    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, Response>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly MovieDbContext _dbContext;
        public DeleteSectionCommandHandler(ISectionRepository SectionRepository, MovieDbContext dbContext)
        {
            _sectionRepository = SectionRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                return await Task.FromResult(new DeleteSectionResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy Section cần xóa"
                });
            }
            var Section = await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            await _sectionRepository.DeleteAsync(request.Id);
            await _sectionRepository.SaveAsync();
            return await Task.FromResult(new DeleteSectionResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa Section thành công",
                Section = CustomMapper.Mapper.Map<SectionDTO>(Section)
            });

        }
    }
}

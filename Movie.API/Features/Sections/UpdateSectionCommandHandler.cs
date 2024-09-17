using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Sections;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Sections
{
    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, Response>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly MovieDbContext _dbContext;
        public UpdateSectionCommandHandler(ISectionRepository SectionRepository, MovieDbContext dbContext)
        {
            _sectionRepository = SectionRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                return await Task.FromResult(new UpdateSectionResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy phần cần cập nhật",
                });
            }
            var Section = await _dbContext.Sections.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            var SectionName = await _dbContext.Sections.AsNoTracking().SingleOrDefaultAsync(x => x.Name == request.Name);
            if (SectionName?.Name != Section?.Name && SectionName != null)
            {
                return await Task.FromResult(new UpdateSectionResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Phần đã tồn tại",
                });
            }
            CustomMapper.Mapper.Map<UpdateSectionCommand, Section>(request, Section);
            Section.LastModifiedDate = DateTime.UtcNow;
            await _sectionRepository.UpdateAsync(Section);
            await _sectionRepository.SaveAsync();
            return await Task.FromResult(new UpdateSectionResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Cập nhật phần thành công",
                Section = CustomMapper.Mapper.Map<SectionDTO>(Section)
            });
        }
    }
}

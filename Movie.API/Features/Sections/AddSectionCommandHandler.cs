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
    public class AddSectionCommandHandler : IRequestHandler<AddSectionCommand, Response>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly MovieDbContext _dbContext;
        public AddSectionCommandHandler(ISectionRepository SectionRepository, MovieDbContext dbContext)
        {
            _sectionRepository = SectionRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddSectionCommand request, CancellationToken cancellationToken)
        {
            var section = CustomMapper.Mapper.Map<Section>(request);
            var sectionExists = await _dbContext.Sections.SingleOrDefaultAsync(x => x.Name == section.Name);
            if (sectionExists != null)
            {
                return await Task.FromResult(new AddSectionResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Phần đã tồn tại",
                });
            }
            section.CreateDate = DateTime.UtcNow;
            await _sectionRepository.AddAsync(section);
            await _sectionRepository.SaveAsync();
            return await Task.FromResult(new AddSectionResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm phần thành công",
                Section = CustomMapper.Mapper.Map<SectionDTO>(section)
            });
        }
    }
}

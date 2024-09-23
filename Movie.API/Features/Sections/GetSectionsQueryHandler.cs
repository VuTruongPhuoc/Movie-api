using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Features.Sections;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Sections
{
    public class GetSectionsQueryHandler : IRequestHandler<GetSectionsQuery, Response>
    {
        private ISectionRepository _sectionRepository;

        public GetSectionsQueryHandler(ISectionRepository SectionRepository)
        {
            _sectionRepository = SectionRepository;
        }
        public async Task<Response> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _sectionRepository.GetAllAsync(request.Pagination.pageNumber, request.Pagination.pageSize);

            var dtos = CustomMapper.Mapper.Map<PaginatedList<SectionDTO>>(categories);

            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = dtos
            });
        }
    }
}

using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Features.Sections;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Sections
{
    public class GetSectionQueryHandler : IRequestHandler<GetSectionQuery, Response>
    {
        private ISectionRepository _sectionRepository;

        public GetSectionQueryHandler(ISectionRepository SectionRepository)
        {
            _sectionRepository = SectionRepository;
        }
        public async Task<Response> Handle(GetSectionQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return await Task.FromResult(new Response()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Yêu cầu trống",

                });
            }
            var Section = await _sectionRepository.GetByIdAsync(request.Id);
            if (Section is null)
            {
                return await Task.FromResult(new Response()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy phần"
                });
            }
            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = CustomMapper.Mapper.Map<SectionDTO>(Section)

            });
        }
    }
}

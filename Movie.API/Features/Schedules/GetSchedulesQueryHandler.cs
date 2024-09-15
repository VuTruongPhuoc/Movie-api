using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Schedules
{
    public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, Response>
    {
        private IScheduleRepository _scheduleRepository;
       
        public GetSchedulesQueryHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        } 
        public async Task<Response> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _scheduleRepository.GetAllAsync();

            var dtos = CustomMapper.Mapper.Map<List<ScheduleDTO>>(categories);

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

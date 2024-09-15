using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Schedules
{
    public class AddScheduleCommandHandler : IRequestHandler<AddScheduleCommand, Response>
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly MovieDbContext _dbContext;
        public AddScheduleCommandHandler(IScheduleRepository scheduleRepository, MovieDbContext dbContext)
        {
            _scheduleRepository = scheduleRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = CustomMapper.Mapper.Map<Schedule>(request);
            var scheduleExists = await _dbContext.Schedules.SingleOrDefaultAsync(x => x.Name == schedule.Name);
            if (scheduleExists != null)
            {
                return await Task.FromResult(new AddScheduleResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Lịch đã tồn tại",
                });
            }
            schedule.CreateDate = DateTime.UtcNow;
            await _scheduleRepository.AddAsync(schedule);
            await _scheduleRepository.SaveAsync();
            return await Task.FromResult(new AddScheduleResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm lịch thành công",
                Schedule = CustomMapper.Mapper.Map<ScheduleDTO>(schedule)
            });
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Histories
{
    public class GetHistoriesQueryHandler : IRequestHandler<GetHistoriesQuery, Response>
    {
        private readonly MovieDbContext _dbContext;

        public GetHistoriesQueryHandler( MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(GetHistoriesQuery request, CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Histories.Where(x => x.UserId == request.UserId).ToListAsync();

            var dtos = CustomMapper.Mapper.Map<List<HistoryDTO>>(comments);

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

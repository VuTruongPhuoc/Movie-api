using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Histories
{
    public class GetHistoriesQueryHandler : IRequestHandler<GetHistoriesQuery, Response>
    {
        private readonly IHistoryRepository _historyRepository;

        public GetHistoriesQueryHandler(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }
        public async Task<Response> Handle(GetHistoriesQuery request, CancellationToken cancellationToken)
        {
            var comments = await _historyRepository.GetAllAsync(request.Pagination.pageNumber, request.Pagination.pageSize, request.UserId);

            var dtos = CustomMapper.Mapper.Map<PaginatedList<HistoryDTO>>(comments);

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

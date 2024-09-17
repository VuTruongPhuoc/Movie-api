using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Histories
{
    public class DeleteHistoryCommandHandler : IRequestHandler<DeleteHistoryCommand, Response>
    {
        private readonly IHistoryRepository _historyRepository;
        private readonly MovieDbContext _dbContext;
        public DeleteHistoryCommandHandler(IHistoryRepository historyRepository, MovieDbContext dbContext)
        {
            _historyRepository = historyRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(DeleteHistoryCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return await Task.FromResult(new DeleteHistoryResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy đánh giá cần xóa"
                });
            }
            var history = await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            await _historyRepository.DeleteAsync(request.Id);
            await _historyRepository.SaveAsync();
            return await Task.FromResult(new DeleteHistoryResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa đánh giá thành công",
                History = CustomMapper.Mapper.Map<HistoryDTO>(history)
            });

        }
    }
}

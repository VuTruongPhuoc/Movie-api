using MediatR;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Histories
{
    public class AddHistoryCommandHandler : IRequestHandler<AddHistoryCommand, Response>
    {
        private readonly IHistoryRepository _historyRepository;
        private readonly MovieDbContext _dbContext;
        public AddHistoryCommandHandler(IHistoryRepository historyRepository, MovieDbContext dbContext)
        {
            _historyRepository = historyRepository;
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(AddHistoryCommand request, CancellationToken cancellationToken)
        {
            var history = CustomMapper.Mapper.Map<History>(request);
            history.CreateDate = DateTime.UtcNow;
            await _historyRepository.AddAsync(history);
            await _historyRepository.SaveAsync();
            return await Task.FromResult(new AddHistoryResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Lịch sử đã thêm phim thành công",
                History = CustomMapper.Mapper.Map<HistoryDTO>(history)
            });
        }
    }
}

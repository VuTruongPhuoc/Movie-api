using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Reviews;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Reviews
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, Response>
    {
        private readonly MovieDbContext _dbContext;

        public GetReviewsQueryHandler(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Reviews.Where(x => x.FilmId == request.FilmId).ToListAsync();

            var dtos = CustomMapper.Mapper.Map<List<ReviewDTO>>(comments);

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

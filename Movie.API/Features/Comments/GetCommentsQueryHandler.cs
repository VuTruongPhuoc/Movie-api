using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Comments;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Comments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, Response>
    {
        private readonly MovieDbContext _dbContext;

        public GetCommentsQueryHandler(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Comments.Where(x => x.FilmId == request.FilmId).ToListAsync();

            var dtos = CustomMapper.Mapper.Map<List<CommentDTO>>(comments);

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

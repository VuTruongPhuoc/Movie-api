using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Comments;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Comments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, Response>
    {
        private readonly MovieDbContext _dbContext;
        private ICommentRepository _commentRepository;

        public GetCommentsQueryHandler(MovieDbContext dbContext, ICommentRepository commentRepository)
        {
            _dbContext = dbContext;
            _commentRepository = commentRepository;
        }
        public async Task<Response> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllAsync(request.Pagination.pageNumber, request.Pagination.pageSize, request.FilmId);

            var dtos = CustomMapper.Mapper.Map<PaginatedList<CommentDTO>>(comments);

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

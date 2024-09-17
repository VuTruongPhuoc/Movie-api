using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Comments
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Response>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly MovieDbContext _dbContext;
        public DeleteCommentCommandHandler(ICommentRepository commentRepository, MovieDbContext dbContext)
        {
            _commentRepository = commentRepository;
            _dbContext = dbContext;
        }
        public async Task<Response> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return await Task.FromResult(new DeleteCommentResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy comment cần xóa"
                });
            }
            var comment = await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.Id);
            await _commentRepository.DeleteAsync(request.Id);
            await _commentRepository.SaveAsync();
            return await Task.FromResult(new DeleteCommentResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa bình luận thành công",
                Comment = CustomMapper.Mapper.Map<CommentDTO>(comment)
            });

        }
    }
}

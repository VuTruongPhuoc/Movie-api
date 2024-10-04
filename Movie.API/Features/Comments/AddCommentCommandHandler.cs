using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Comments
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, AddCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly MovieDbContext _dbContext;
        public AddCommentCommandHandler(ICommentRepository commentRepository, MovieDbContext dbContext)
        {
            _commentRepository = commentRepository;
            _dbContext = dbContext;
        }

        public async Task<AddCommentResponse> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = CustomMapper.Mapper.Map<Comment>(request);
            comment.CreateDate = DateTime.UtcNow;
            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveAsync();

            var dto = CustomMapper.Mapper.Map<CommentDTO>(comment);
            dto.User = CustomMapper.Mapper.Map<UserDTO>(await _dbContext.Users.FindAsync(comment.UserId));


            return await Task.FromResult(new AddCommentResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Bình luận thành công",
                Comment = dto
            });
        }
    }
}

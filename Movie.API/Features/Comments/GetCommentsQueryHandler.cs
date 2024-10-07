using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Comments;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Comments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, DataRespone>
    {
        private readonly MovieDbContext _dbContext;
        private ICommentRepository _commentRepository;
        private UserManager<User> _userManager;
        public GetCommentsQueryHandler(MovieDbContext dbContext, ICommentRepository commentRepository, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _commentRepository = commentRepository;
            _userManager = userManager;
        }
        public async Task<DataRespone> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Comments
                            .Include(x => x.Feedbacks)
                                .ThenInclude(x => x.User)
                            .Include(x => x.User)
                            .Where(x => x.FilmId == request.FilmId)
                            .OrderByDescending(x => x.CreateDate)
                            .ToListAsync();

            var commentDtos = comments.Select(comment =>
            {
                var dto = CustomMapper.Mapper.Map<CommentDTO>(comment);
                dto.Feedbacks = comment.Feedbacks
                            .Select(c => CustomMapper.Mapper.Map<FeedbackDTO>(c))
                            .ToList();
                dto.User = CustomMapper.Mapper.Map<UserDTO>(comment.User);
                return dto;
            }).ToList(); 

            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = commentDtos
            });
        }
    }
}

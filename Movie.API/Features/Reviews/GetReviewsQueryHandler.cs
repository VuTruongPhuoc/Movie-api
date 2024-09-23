using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Reviews;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Reviews
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, Response>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewsQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Response> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _reviewRepository.GetAllAsync(request.Pagination.pageNumber, request.Pagination.pageSize, request.FilmId);

            var dtos = CustomMapper.Mapper.Map<PaginatedList<ReviewDTO>>(comments);

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

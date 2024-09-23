using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Features.Tracks;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Tracks
{
    public class GetTracksQueryHandler : IRequestHandler<GetTracksQuery, Response>
    {
        private readonly ITrackRepository _trackRepository;

        public GetTracksQueryHandler(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public async Task<Response> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            var comments = await _trackRepository.GetAllAsync(request.Pagination.pageNumber, request.Pagination.pageSize, request.UserId);

            var dtos = CustomMapper.Mapper.Map<PaginatedList<TrackDTO>>(comments);

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

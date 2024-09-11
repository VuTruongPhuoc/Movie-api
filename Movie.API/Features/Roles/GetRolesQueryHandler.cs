using MediatR;
using Microsoft.AspNetCore.Identity;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Roles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, Respone>
    {
        private readonly RoleManager<Role> _roleManager;
        public GetRolesQueryHandler( RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Respone> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {

            return new DataRespone()
            {
                Success = true,
                Message = "ok",
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = request.Roles
            };
        }
    }
}

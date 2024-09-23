﻿using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Users
{
    public class ChangeRoleCommand : IRequest<Response>
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}

﻿using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Sections
{
    public class DeleteSectionCommand : DeleteSectionRequest, IRequest<Response>
    {
        public int Id { get; set; }
    }
}

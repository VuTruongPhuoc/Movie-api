using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Movie.API.AutoMapper;
using Movie.API.Features.Countries;
using Movie.API.Features.Films;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Requests;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace Movie.API.Controllers
{
    [Route("api/film")]
    [ApiController] 
    public class FilmController : BaseController
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMediator _mediator;
        public FilmController(IMediator mediator, IFilmRepository filmRepository, IWebHostEnvironment hostEnvironment) : base(hostEnvironment)
        {
            _mediator = mediator;
            _filmRepository = filmRepository;
        }
        [HttpGet("all")]
        public async Task<DataRespone> GetFilms()
        {
            var query = new GetFilmsQuery() { };
            var filmsResponse = await _mediator.Send(query);

            foreach (var image in filmsResponse.Data)
            {
                image.ImageUrl = $"{Request.Scheme}://{Request.Host}/Content/Images/{image.Image}";
                image.PosterUrl = $"{Request.Scheme}://{Request.Host}/Content/Images/{image.Poster}";

            }

            return new DataRespone
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = filmsResponse.Data
            };
        }
        [HttpGet("get/{slug}")]
        public async Task<IActionResult> GetFilmBySlug(string slug)
        {
            var query = new GetFilmBySlugQuery() { Slug = slug };
            var filmResponse = await _mediator.Send(query);
            if(filmResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(filmResponse);
            } else if(filmResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(filmResponse);
            }
            filmResponse.Film.ImageUrl = $"{Request.Scheme}://{Request.Host}/Content/Images/{filmResponse.Film.Image}";
            filmResponse.Film.PosterUrl = $"{Request.Scheme}://{Request.Host}/Content/Images/{filmResponse.Film.Poster}";

            return Ok(new GetFilmBySlugResponse
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Film = filmResponse.Film,
                Episodes = filmResponse.Episodes

            });
        }
        [HttpGet("{id}")]
        public async Task<Response> GetFilm(int id)
        {
            var query = new GetFilmQuery() { Id = id};
            return await _mediator.Send(query);
        }
        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddFilm([FromBody] AddFilmRequest model)
        {
            var command = new AddFilmCommand();
            CustomMapper.Mapper.Map<AddFilmRequest, AddFilmCommand>(model, command);
            var response = await _mediator.Send(command);
            if(response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateFilm(int id, [FromBody] UpdateFilmRequest model)
        {
            var command = new UpdateFilmCommand() { Id = id};
            CustomMapper.Mapper.Map<UpdateFilmRequest, UpdateFilmCommand>(model, command);
            var response = await _mediator.Send(command);
            if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var command = new DeleteFilmCommand() { Id = id};
            var response = await _mediator.Send(command);
            if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]

        [HttpPost("changefilmimage/{id}")]
        public async Task<IActionResult> ChangeFilmImage(int id, [FromForm] ChangeFilmImageRequest model)
        {
            if (id != model.Id)
            {
                return BadRequest(new Response
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = null
                });
            }
            var film = await _filmRepository.GetByIdAsync(id);
            if (model.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(film.Image))
                {
                    DeleteImage(film.Image);
                }
                film.Image = await SaveImage(model.ImageFile);
            }
            if (film is null)
            {
                return NotFound(new Response()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy",
                });
            }

            CustomMapper.Mapper.Map<ChangeFilmImageRequest, Film>(model, film);
            film.Image = Path.Combine(film.Image);
            await _filmRepository.UpdateAsync(film);
            await _filmRepository.SaveAsync();

            var dto = CustomMapper.Mapper.Map<FilmImage>(film);
            dto.ImageUrl = $"{Request.Scheme}://{Request.Host}/Content/Images/{dto.Image}";
            return Ok(new FilmImageResponse
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Film = dto
            });
        }
        [Authorize]

        [HttpPost("changefilmposter/{id}")]
        public async Task<IActionResult> ChangeFilmPoster(int id, [FromForm] ChangeFilmPosterRequest model)
        {
            if (id != model.Id)
            {
                return BadRequest(new Response
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = null
                });
            }
            var film = await _filmRepository.GetByIdAsync(id);
            if (model.PosterFile != null)
            {
                if (!string.IsNullOrEmpty(film.Poster))
                {
                    DeleteImage(film.Poster);
                }
                film.Poster = await SaveImage(model.PosterFile);
            }
            if (film is null)
            {
                return NotFound(new Response()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy",
                });
            }

            CustomMapper.Mapper.Map<ChangeFilmPosterRequest, Film>(model, film);
            film.Poster = Path.Combine(film.Poster);
            await _filmRepository.UpdateAsync(film);
            await _filmRepository.SaveAsync();

            var dto = CustomMapper.Mapper.Map<FilmPoster>(film);
            dto.PosterUrl = $"{Request.Scheme}://{Request.Host}/Content/Images/{dto.Poster}";
            return Ok(new FilmPosterResponse
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Film = dto
            });
        }
    }
}

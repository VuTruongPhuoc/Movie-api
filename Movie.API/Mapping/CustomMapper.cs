using AutoMapper;
using Movie.API.Features.Categories;
using Movie.API.Features.Comments;
using Movie.API.Features.Countries;
using Movie.API.Features.Films;
using Movie.API.Features.Histories;
using Movie.API.Features.Reviews;
using Movie.API.Features.Roles;
using Movie.API.Features.Schedules;
using Movie.API.Features.Sections;
using Movie.API.Features.Tracks;
using Movie.API.Features.Users;
using Movie.API.Models.Domain.Entities;
using Movie.API.Requests;
using Movie.API.Responses.DTOs;

namespace Movie.API.AutoMapper
{
    public static class CustomMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<FilmProfile>();
                cfg.AddProfile<RoleProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<CountryProfile>();
                cfg.AddProfile<ScheduleProfile>();
                cfg.AddProfile<SectionProfile>();
                cfg.AddProfile<CommentProfile>();
                cfg.AddProfile<ReviewProfile>();
                cfg.AddProfile<HistoryProfile>();
                cfg.AddProfile<TrackProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }


    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ForMember(x => x.DisplayName, d => d.MapFrom(x => x.DisplayName)).ReverseMap();
            CreateMap<AddUserRequest, AddUserCommand>().ReverseMap();
            CreateMap<UpdateUserRequest, UpdateUserCommand>().ReverseMap();
            CreateMap<User, AddUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, RegisterRequest>().ReverseMap();
        }
    } 
    public class FilmProfile: Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, FilmDTO>().ReverseMap();
            CreateMap<Film, AddFilmCommand>().ReverseMap();
            CreateMap<Film, UpdateFilmCommand>().ReverseMap();
            CreateMap<Film, UpdateFilmRequest>().ReverseMap();
            CreateMap<AddFilmRequest, AddFilmCommand>().ReverseMap();
            CreateMap<UpdateFilmCommand, UpdateFilmRequest>().ReverseMap();
        }
    }
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, AddCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<CategoryDTO, UpdateCategoryRequest>().ReverseMap();
            CreateMap<UpdateCategoryCommand, UpdateCategoryRequest>().ReverseMap();
        }
    }
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, AddCountryCommand>().ReverseMap();
            CreateMap<Country, UpdateCountryCommand>().ReverseMap();
            CreateMap<CountryDTO, UpdateCategoryRequest>().ReverseMap();
            CreateMap<UpdateCountryCommand, UpdateCategoryRequest>().ReverseMap();
        }
    }
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Schedule, AddScheduleCommand>().ReverseMap();
            CreateMap<Schedule, UpdateScheduleCommand>().ReverseMap();
            CreateMap<ScheduleDTO, UpdateScheduleRequest>().ReverseMap();
            CreateMap<UpdateScheduleCommand, UpdateScheduleRequest>().ReverseMap();
        }
    }
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDTO>().ReverseMap();
            CreateMap<Section, AddSectionCommand>().ReverseMap();
            CreateMap<Section, UpdateSectionCommand>().ReverseMap();
            CreateMap<SectionDTO, UpdateSectionRequest>().ReverseMap();
            CreateMap<AddSectionRequest, AddSectionCommand>().ReverseMap();
            CreateMap<UpdateSectionCommand, UpdateSectionRequest>().ReverseMap();
        }
    }
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Comment, AddCommentCommand>().ReverseMap();
            CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
            CreateMap<CommentDTO, UpdateCommentRequest>().ReverseMap();
            CreateMap<AddCommentRequest, AddCommentCommand>().ReverseMap();
            CreateMap<UpdateCommentCommand, UpdateCommentRequest>().ReverseMap();
        }   
    }
    public class TrackProfile : Profile
    {
        public TrackProfile()
        {
            CreateMap<Track, TrackDTO>().ReverseMap();
            CreateMap<Track, AddTrackCommand>().ReverseMap();
            CreateMap<AddTrackRequest, AddTrackCommand>().ReverseMap();
        }
    }
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Review, AddReviewCommand>().ReverseMap();
            CreateMap<AddReviewRequest, AddReviewCommand>().ReverseMap();
        }
    }
    public class HistoryProfile : Profile
    {
        public HistoryProfile()
        {
            CreateMap<History, HistoryDTO>().ReverseMap();
            CreateMap<History, AddHistoryCommand>().ReverseMap();
            CreateMap<AddHistoryRequest, AddHistoryCommand>().ReverseMap();
        }
    }
}

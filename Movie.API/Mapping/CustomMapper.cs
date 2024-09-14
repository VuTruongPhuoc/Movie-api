using AutoMapper;
using Movie.API.Features.Roles;
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

        }
    } 
    public class FilmProfile: Profile
    {
        public FilmProfile()
        {

            CreateMap<Film, FilmDTO>().ReverseMap();
        }
    }
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}

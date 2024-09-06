using Movie.API.Infrastructure.Repositories;

namespace Movie.API
{
    public static class DI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IFilmRepository, FilmRepository>();
            return services;
        }
    }
}

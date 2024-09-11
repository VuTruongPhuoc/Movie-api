using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movie.API.Infrastructure.Repositories;
using System.Text;

namespace Movie.API
{
    public static class DI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DI).Assembly);
            });
            services.AddScoped<AccountManager>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            return services;
        }
        #region configure authen
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebAPI",
                    Description = "",
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme. Enter your token in the text input. Example: Bearer asdkfjds",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.Http

                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme,

                            },
                            Scheme = "oauth2",
                            Name = "bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            var key = Encoding.ASCII.GetBytes(configuration["JWTSecret"]);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = configuration["LocalIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["LocalAudience"]

                };
            });
            return services;
        }
        #endregion
    }
}

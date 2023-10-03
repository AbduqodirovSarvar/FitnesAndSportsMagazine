using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;
using Fitnes.Infrastructure.DbContexts;
using Fitnes.Infrastructure.Models;
using Fitnes.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Fitnes.Infrastructure
{
    public static class DepencyInjection
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppDbContext>(options
                => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddSingleton<IDesignTimeDbContextFactory<AppDbContext>>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                return new AppDbContextFactory();
            });

            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddScoped<ITokenService, TokenService>();

            services.Configure<JWTConfiguration>(configuration.GetSection("JWTConfiguration"));

            var secretWord = configuration["JWTConfiguration:Secret"];

            if (secretWord == null || secretWord.Length <= 1)
            {
                throw new ArgumentNullException("Secret word for authorization", nameof(secretWord));
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = configuration["JWTConfiguration:ValidAudience"],
                        ValidIssuer = configuration["JWTConfiguration:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretWord))
                    };
                });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRole.Admin.ToString());
                });
                option.AddPolicy("ConsumerAction", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRole.Consumer.ToString());
                });
                option.AddPolicy("TeacherAction", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRole.Teacher.ToString());
                });
            });

            return services;
        }
    }
}

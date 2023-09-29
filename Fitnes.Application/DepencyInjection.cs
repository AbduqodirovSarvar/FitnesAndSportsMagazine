using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Mappings;
using Fitnes.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fitnes.Application
{
    public static class DepencyInjection
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DepencyInjection).Assembly);
            });

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<IFileSaveToFolder, FileSaveToFolder>();
            services.AddTransient<IMailSender, MailSender>();
            //services.AddTransient<SmtpClient>();
            var mappingconfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new Mapping());
            });

            IMapper mapper = mappingconfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}

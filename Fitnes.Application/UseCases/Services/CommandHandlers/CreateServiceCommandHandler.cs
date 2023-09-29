using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Services.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Services.CommandHandlers
{
    public class CreateServiceCommandHandler : ICommandHandler<CreateServiceCommand, Service>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        public CreateServiceCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Service> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await context.Services.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);
            if (service != null)
            {
                throw new Exception("Service already exists");
            }

            service = mapper.Map<Service>(request);

            await context.Services.AddAsync(service, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return service;
        }
    }
}

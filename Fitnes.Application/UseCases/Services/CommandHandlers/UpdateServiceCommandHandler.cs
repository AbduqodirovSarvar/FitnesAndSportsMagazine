using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Services.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Services.CommandHandlers
{
    public class UpdateServiceCommandHandler : ICommandHandler<UpdateServiceCommand, Service>
    {
        private readonly IAppDbContext context;
        public UpdateServiceCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<Service> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await context.Services.FirstOrDefaultAsync(x => x.Id == request.ServiceId, cancellationToken);
            if (service == null)
            {
                throw new Exception("Service not found");
            }

            service.Name = request.Name ?? service.Name;
            service.Description = request.Description ?? service.Description;

            await context.SaveChangesAsync(cancellationToken);

            return service;
        }
    }
}

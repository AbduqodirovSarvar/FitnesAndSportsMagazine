using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Services.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Services.CommandHandlers
{
    public class DeleteServiceCommandHandler : ICommandHandler<DeleteServiceCommand, bool>
    {
        private readonly IAppDbContext context;
        public DeleteServiceCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await context.Services.FirstOrDefaultAsync(x => x.Id == request.ServiceId, cancellationToken);
            if (service == null)
            {
                throw new Exception("Service not found");
            }

            context.Services.Remove(service);

            return (await context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

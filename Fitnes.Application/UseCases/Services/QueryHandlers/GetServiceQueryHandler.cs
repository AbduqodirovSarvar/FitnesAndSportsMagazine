using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Services.Queries;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Services.QueryHandlers
{
    public class GetServiceQueryHandler : IQueryHandler<GetServiceQuery, Service>
    {
        private readonly IAppDbContext context;
        public GetServiceQueryHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<Service> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var service = await context.Services.FirstOrDefaultAsync(x => x.Id == request.ServiceId, cancellationToken);
            if (service == null)
            {
                throw new Exception("Service not found");
            }
            return service;
        }
    }
}

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
    public class GetAllServiceQueryHandler : IQueryHandler<GetAllServiceQuery, List<Service>>
    {
        private readonly IAppDbContext context;
        public GetAllServiceQueryHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Service>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
        {
            return context.Services.ToListAsync(cancellationToken);
        }
    }
}

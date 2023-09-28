using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Users.Queries;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Users.QueryHandlers
{
    public class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, List<User>>
    {
        private readonly IAppDbContext context;
        public GetAllUserQueryHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await context.Users.ToListAsync(cancellationToken);
            return users;
        }
    }
}

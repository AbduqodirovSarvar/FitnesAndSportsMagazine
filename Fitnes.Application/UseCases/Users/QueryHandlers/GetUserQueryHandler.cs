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
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, User>
    {
        private readonly IAppDbContext context;
        public GetUserQueryHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }
    }
}

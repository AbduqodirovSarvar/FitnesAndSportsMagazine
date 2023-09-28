using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Users.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Users.CommandHandlers
{
    internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        private readonly IAppDbContext context;
        public DeleteUserCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            if(user == null)
            {
                return false;
            }

            context.Users.Remove(user);
            return (await context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

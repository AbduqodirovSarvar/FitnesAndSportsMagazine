using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Authorize.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Authorize.CommandHandlers
{
    public class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand, bool>
    {
        private readonly IAppDbContext context;
        private readonly IHashService hashService;
        public ResetPasswordCommandHandler(IAppDbContext context, IHashService hashService)
        {
            this.context = context;
            this.hashService = hashService;
        }

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            if(user == null)
            {
                throw new Exception("User not found");
            }

            user.PasswordHash = hashService.GetHash(request.Password);
            return (await context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

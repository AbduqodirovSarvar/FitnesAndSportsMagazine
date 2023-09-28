using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Users.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fitnes.Application.UseCases.Users.CommandHandlers
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, User>
    {
        private readonly IAppDbContext context;
        private readonly IFileSaveToFolder fileSaveToFolder;
        public UpdateUserCommandHandler(IAppDbContext context, IFileSaveToFolder fileSaveToFolder)
        {
            this.context = context;
            this.fileSaveToFolder = fileSaveToFolder;
        }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.FirstName = request.FirstName ?? user.FirstName;
            user.LastName = request.LastName ?? user.LastName;
            user.Days = request.Days ?? user.Days;
            user.BirthDay = request.BirthDay ?? user.BirthDay;
            if(request.Image!= null)
            {
                user.ImageName = await fileSaveToFolder.SaveToFolderAsync(request.Image);
            }
            user.ServiceId = request.ServiceId ?? user.ServiceId;
            user.Phone = request.Phone ?? user.Phone;
            user.Email = request.Email ?? user.Email;
            
            return user;
        }
    }
}

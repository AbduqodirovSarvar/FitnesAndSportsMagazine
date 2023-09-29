using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Users.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Users.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, User>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly IFileSaveToFolder fileSaveToFolder;
        public CreateUserCommandHandler(IAppDbContext context, IMapper mapper, IFileSaveToFolder fileSaveToFolder)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileSaveToFolder = fileSaveToFolder;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await context.Users.AnyAsync(x => x.Email == request.Email || x.Phone == request.Phone, cancellationToken))
            {
                throw new Exception("User already exists");
            }

            var user = mapper.Map<User>(request);

            if (request.Image != null || request.Image?.Length > 0)
            {
                user.ImageName = await fileSaveToFolder.SaveToFolderAsync(request.Image);
            }

            await context.Users.AddAsync(user, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}

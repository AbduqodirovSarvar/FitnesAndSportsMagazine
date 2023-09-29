using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Chats.Commands;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Chats.CommandHandlers
{
    public class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand, bool>
    {
        private readonly IAppDbContext context;
        private readonly ICurrentUserService currentUserService;
        public DeleteMessageCommandHandler(IAppDbContext context, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        public async Task<bool> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Include(x => x.Chat).ThenInclude(z => z.Messages).FirstOrDefaultAsync(x => x.Id == currentUserService.UserId, cancellationToken);

            var message = await context.Messages.FirstOrDefaultAsync(x => x.Id == request.MessageId, cancellationToken);

            if (user == null || message == null || user.Chat == null || user.Chat.Messages.Count < 1 || message.SenderId != user.Id)
            {
                throw new Exception("Message not found or acces denied");
            }

            user.Chat.Messages.Remove(message);

            return (await context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

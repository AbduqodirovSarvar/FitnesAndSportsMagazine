using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Cards.Commands;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Cards.CommandHandlers
{
    public class DeleteCardCommandHandler : ICommandHandler<DeleteCardsCommand, bool>
    {
        private readonly IAppDbContext context;
        private readonly ICurrentUserService currentUserService;
        public DeleteCardCommandHandler(IAppDbContext context, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        public async Task<bool> Handle(DeleteCardsCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Include(x => x.Cards).FirstOrDefaultAsync(x => x.Id == currentUserService.UserId, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var card = user.Cards.FirstOrDefault(x => x.Id == request.CardId);
            if (card == null)
            {
                throw new Exception("Card not found");
            }

            context.Cards.Remove(card);

            return (await context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

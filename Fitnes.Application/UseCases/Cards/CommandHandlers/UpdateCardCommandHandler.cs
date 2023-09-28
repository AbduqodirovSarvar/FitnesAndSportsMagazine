using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Cards.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Cards.CommandHandlers
{
    public class UpdateCardCommandHandler : ICommandHandler<UpdateCardsCommand, CardViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public UpdateCardCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<CardViewModel> Handle(UpdateCardsCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Include(x => x.Cards).FirstOrDefaultAsync(x => x.Id == currentUserService.UserId, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var card = user.Cards.FirstOrDefault(x => x.ProductId == request.ProductId);
            if (card == null)
            {
                throw new Exception("Card not found");
            }

            card.Amount = request.Amount ?? card.Amount;

            if(card.Amount < 1)
            {
                context.Cards.Remove(card);
            }

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<CardViewModel>(card);
        }
    }
}

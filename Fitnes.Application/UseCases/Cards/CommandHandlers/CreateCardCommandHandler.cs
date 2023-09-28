using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Cards.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Cards.CommandHandlers
{
    public class CreateCardCommandHandler : ICommandHandler<CreateCardsCommand, CardViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public CreateCardCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<CardViewModel> Handle(CreateCardsCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == currentUserService.UserId, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not Found");
            }

            var card = mapper.Map<Card>(request);
            card.UserId = user.Id;

            await context.Cards.AddAsync(card, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<CardViewModel>(card);
        }
    }
}

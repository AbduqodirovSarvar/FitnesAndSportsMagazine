using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Cards.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Cards.QueryHandlers
{
    public class GetCardsQueryHandler : IQueryHandler<GetCardsQuery, CardViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public GetCardsQueryHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<CardViewModel> Handle(GetCardsQuery request, CancellationToken cancellationToken)
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

            return mapper.Map<CardViewModel>(card);
        }
    }
}

using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Cards.Queries;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Cards.QueryHandlers
{
    public class GetAllCardsQueryHandler : IQueryHandler<GetAllCardsQuery, List<CardViewModel>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public GetAllCardsQueryHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<List<CardViewModel>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Include(x => x.Cards).FirstOrDefaultAsync(x => x.Id == currentUserService.UserId, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return mapper.Map<List<CardViewModel>>(user.Cards);
        }
    }
}

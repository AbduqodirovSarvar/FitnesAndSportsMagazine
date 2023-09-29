using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Chats.Queries;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Chats.QueryHandlers
{
    public class GetAllChatsQueryHandlers : IQueryHandler<GetAllChatsQuery, List<ChatViewModel>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public GetAllChatsQueryHandlers(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<List<ChatViewModel>> Handle(GetAllChatsQuery request, CancellationToken cancellationToken)
        {
            var chats = await context.Chats.Include(x => x.Messages).ToListAsync(cancellationToken);
            return mapper.Map<List<ChatViewModel>>(chats);
        }
    }
}

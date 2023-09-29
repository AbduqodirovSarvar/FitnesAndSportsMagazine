using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Chats.Queries;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Chats.QueryHandlers
{
    public class GetChatQueryHandlers : IQueryHandler<GetChatQuery, ChatViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public GetChatQueryHandlers(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<ChatViewModel> Handle(GetChatQuery request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Include(x => x.Chat).ThenInclude(x => x.Messages).FirstOrDefaultAsync(x => x.Id == currentUserService.UserId, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var chat = await context.Chats.Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == request.ChatId, cancellationToken);

            if (chat == null || (user.Role != Domain.Enums.UserRole.Admin && chat.UserId != currentUserService.UserId))
            {
                throw new Exception("Chat not found or acces denied");
            }
            return mapper.Map<ChatViewModel>(chat);
        }
    }
}

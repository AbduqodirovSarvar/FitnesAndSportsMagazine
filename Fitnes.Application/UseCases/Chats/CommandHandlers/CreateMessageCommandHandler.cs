using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Chats.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Chats.CommandHandlers
{
    public class CreateMessageCommandHandler : ICommandHandler<CreateMessageCommand, ChatViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public CreateMessageCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<ChatViewModel> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Include(x => x.Chat).ThenInclude(x => x.Messages).FirstOrDefaultAsync(x => x.Id == currentUserService.UserId, cancellationToken);
            if(user == null)
            {
                throw new Exception("User not found");
            }

            var chat = await context.Chats.Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == request.ChatId, cancellationToken);

            if (chat == null)
            {
                chat = new Chat()
                {
                    UserId = user.Id
                };

                await context.Chats.AddAsync(chat, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
            if(chat.UserId == user.Id || user.Role == Domain.Enums.UserRole.Admin)
            {
                var message = mapper.Map<Message>(request);
                message.SenderId = user.Id;
                message.ChatId = chat.Id;
                await context.Messages.AddAsync(message, cancellationToken);
            }
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<ChatViewModel>(chat);
        }
    }
}

using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.Services;
using Fitnes.Application.UseCases.Users.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Users.CommandHandlers
{
    public class CreateConsumerCommandHandler : ICommandHandler<CreateConsumerCommand, ConsumerViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly IFileSaveToFolder fileSaveToFolder;
        public CreateConsumerCommandHandler(IAppDbContext context, IMapper mapper, IFileSaveToFolder fileSaveToFolder)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileSaveToFolder = fileSaveToFolder;
        }

        public async Task<ConsumerViewModel> Handle(CreateConsumerCommand request, CancellationToken cancellationToken)
        {
            if (await context.Users.AnyAsync(x => x.Email == request.Email || x.Phone == request.Phone, cancellationToken))
            {
                throw new Exception("Teacher already exists");
            }

            var consumer = mapper.Map<Consumer>(request);

            if (request.Image != null || request.Image?.Length > 0)
            {
                consumer.User.ImageName = await fileSaveToFolder.SaveToFolderAsync(request.Image);
            }

            await context.Users.AddAsync(consumer.User, cancellationToken);
            await context.Consumers.AddAsync(consumer, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<ConsumerViewModel>(consumer);
        }
    }
}

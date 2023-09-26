using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Users.CommandHandlers
{
    public class CreateAdminCommandHandler : ICommandHandler<CreateAdminCommand, AdminViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        public CreateAdminCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<AdminViewModel> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

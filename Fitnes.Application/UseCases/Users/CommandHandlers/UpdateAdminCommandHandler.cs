using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Users.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Users.CommandHandlers
{
    public class UpdateAdminCommandHandler : ICommandHandler<UpdateAdminCommand, AdminViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly IFileSaveToFolder fileSaveToFolder;
        public UpdateAdminCommandHandler(IAppDbContext context, IMapper mapper, IFileSaveToFolder fileSaveToFolder)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileSaveToFolder = fileSaveToFolder;
        }

        public async Task<AdminViewModel> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await context.Admins.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.AdminId, cancellationToken);
            if (admin == null)
            {
                throw new Exception("Admin not found");
            }
            admin.User.FirstName = request.FirstName ?? admin.User.FirstName;
            admin.User.LastName = request.LastName ?? admin .User.LastName;
            admin.User.Email = request.Email ?? admin.User.Email;
            admin.User.BirthDay = request.BirthDay ?? admin.User.BirthDay;
            admin.User.Phone = request.Phone ?? admin.User.Phone;
            
            throw new NotImplementedException();
        }
    }
}

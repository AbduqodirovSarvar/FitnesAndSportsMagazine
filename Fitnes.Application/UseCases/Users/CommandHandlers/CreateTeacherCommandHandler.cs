using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
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
    public class CreateTeacherCommandHandler : ICommandHandler<CreateTeacherCommand, TeacherViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly IFileSaveToFolder fileSaveToFolder;
        private readonly IMailSender mailSender;
        public CreateTeacherCommandHandler(IAppDbContext context, IMapper mapper, IFileSaveToFolder fileSaveToFolder, IMailSender mailSender)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileSaveToFolder = fileSaveToFolder;
            this.mailSender = mailSender;
        }

        public async Task<TeacherViewModel> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            //await mailSender.SendMessage("sarvarabduqodirov.2002@gmail.com", "hello");

            if(await context.Users.AnyAsync(x => x.Email == request.Email || x.Phone == request.Phone, cancellationToken))
            {
                throw new Exception("Teacher already exists");
            }

            var teacher = mapper.Map<Teacher>(request);

            if (request.Image != null || request.Image?.Length > 0)
            {
                teacher.UserTeacher.ImageName = await fileSaveToFolder.SaveToFolderAsync(request.Image);
            }

            await context.Users.AddAsync(teacher.UserTeacher, cancellationToken);
            await context.Teachers.AddAsync(teacher, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            
            return mapper.Map<TeacherViewModel>(teacher);
        }
    }
}

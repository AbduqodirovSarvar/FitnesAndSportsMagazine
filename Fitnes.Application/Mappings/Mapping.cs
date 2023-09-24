using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Services;
using Fitnes.Application.UseCases.Users.Commands;
using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Mappings
{
    public class Mapping : Profile
    {
        private readonly IHashService hashService = new HashService();
        public Mapping() 
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.PasswordHash, y => y.MapFrom(z => hashService.GetHash(z.Password)));
        }
    }
}

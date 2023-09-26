using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
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
            CreateMap<CreateConsumerCommand, Consumer>()
                .ForMember(x => x.User, y => y.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Email = src.Email,
                    Phone = src.Phone,
                    PasswordHash = hashService.GetHash(src.Password),
                    BirthDay = src.BirthDay,
                    CreatedDate = DateTime.UtcNow
                }))
                    .ReverseMap();
            CreateMap<CreateAdminCommand, Admin>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Email = src.Email,
                    Phone = src.Phone,
                    PasswordHash = hashService.GetHash(src.Password),
                    BirthDay = src.BirthDay,
                    CreatedDate = DateTime.UtcNow
                }))
                    .ReverseMap();
            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.PasswordHash, y => y.MapFrom(z => hashService.GetHash(z.Password)))
                    .ReverseMap();
            CreateMap<CreateTeacherCommand, Teacher>()
                .ForMember(x => x.UserTeacher, y => y.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Email = src.Email,
                    Phone = src.Phone,
                    PasswordHash = hashService.GetHash(src.Password),
                    BirthDay = src.BirthDay,
                    CreatedDate = DateTime.UtcNow
                }))
                    .ReverseMap();
            CreateMap<User, UserViewModel>()
                .ReverseMap();
            CreateMap<Consumer, ConsumerViewModel>()
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                    .ForMember(x => x.Teacher, y => y.MapFrom(z => z.Teacher))
                        .ForMember(x => x.ConsumerId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<Teacher, TeacherViewModel>()
                .ForMember(x => x.UserTeacher, y => y.MapFrom(z => z.UserTeacher))
                    .ForMember(x => x.Consumers, y => y.MapFrom(z => z.Consumers))
                        .ForMember(x => x.TeacherId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<Admin, AdminViewModel>()
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                    .ForMember(x => x.AdminId, y => y.MapFrom(z => z.Id))
                        .ReverseMap();
            CreateMap<ConsumerService, ConsumerServiceViewModel>()
                .ForMember(x => x.Consumer, y => y.MapFrom(z => z.Consumer))
                    .ForMember(x => x.ServiceId, y => y.MapFrom(z => z.Id))
                        .ReverseMap();
            CreateMap<Message, MessageViewModel>()
                .ForMember(x => x.Admin, y => y.MapFrom(z => z.Admin))
                    .ForMember(x => x.Consumer, y => y.MapFrom(z => z.Consumer))
                        .ForMember(x => x.MessageId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<Order, OrderViewModel>()
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product))
                    .ForMember(x => x.Consumer, y => y.MapFrom(z => z.Consumer))
                        .ForMember(x => x.OrderId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.Orders, y => y.MapFrom(z => z.Orders))
                    .ForMember(x => x.ProductId, y => y.MapFrom(z => z.Id))
                        .ReverseMap();
            CreateMap<Card, CardViewModel>()
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product))
                    .ForMember(x => x.Consumer, y => y.MapFrom(z => z.Consumer))
                        .ForMember(x => x.CardId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
        }
    }
}

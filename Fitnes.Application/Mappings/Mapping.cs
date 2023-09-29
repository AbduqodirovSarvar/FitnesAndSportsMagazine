using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.CreateDto;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.Services;
using Fitnes.Application.UseCases.Chats.Commands;
using Fitnes.Application.UseCases.Products.Commands;
using Fitnes.Application.UseCases.Services.Commands;
using Fitnes.Application.UseCases.Users.Commands;
using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;

namespace Fitnes.Application.Mappings
{
    public class Mapping : Profile
    {
        private readonly IHashService hashService = new HashService();
        public Mapping()
        {
            CreateMap<CreateConsumerDto, CreateUserCommand>()
                .ForMember(x => x.Role, y => y.MapFrom(z => UserRole.Consumer))
                    .ReverseMap();
            CreateMap<CreateAdminDto, CreateUserCommand>()
                .ForMember(x => x.Role, y => y.MapFrom(z => UserRole.Admin))
                    .ReverseMap();
            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.PasswordHash, y => y.MapFrom(z => hashService.GetHash(z.Password)))
                    .ReverseMap();
            CreateMap<CreateTeacherDto, CreateUserCommand>()
                .ForMember(x => x.Role, y => y.MapFrom(z => UserRole.Teacher))
                    .ReverseMap();
            CreateMap<CreateProductCommand, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(z => z.GetProductType()))
                    .ReverseMap();
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.Id))
                    .ReverseMap();
            CreateMap<User, ConsumerViewModel>()
                    .ForMember(x => x.Teacher, y => y.MapFrom(z => z.Teacher))
                        .ForMember(x => x.ConsumerId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<User, TeacherViewModel>()
                    .ForMember(x => x.Consumers, y => y.MapFrom(z => z.Consumers))
                        .ForMember(x => x.TeacherId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<User, AdminViewModel>()
                    .ForMember(x => x.AdminId, y => y.MapFrom(z => z.Id))
                        .ReverseMap();
            CreateMap<UserService, UserServiceViewModel>()
                .ForMember(x => x.Consumer, y => y.MapFrom(z => z.User))
                    .ForMember(x => x.ServiceId, y => y.MapFrom(z => z.Id))
                        .ReverseMap();
            CreateMap<Message, MessageViewModel>()
                        .ForMember(x => x.MessageId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<Order, OrderViewModel>()
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product))
                        .ForMember(x => x.OrderId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.Orders, y => y.MapFrom(z => z.Orders))
                    .ForMember(x => x.ProductId, y => y.MapFrom(z => z.Id))
                        .ReverseMap();
            CreateMap<Card, CardViewModel>()
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product))
                        .ForMember(x => x.CardId, y => y.MapFrom(z => z.Id))
                            .ReverseMap();
            CreateMap<Chat, ChatViewModel>()
                .ForMember(x => x.ChatId, y => y.MapFrom(z => z.Id))
                    .ReverseMap();
            CreateMap<CreateServiceCommand, Service>().ReverseMap();
            CreateMap<CreateMessageDto, CreateMessageCommand>().ReverseMap();
            CreateMap<CreateMessageCommand, Message>().ReverseMap();
        }
    }
}

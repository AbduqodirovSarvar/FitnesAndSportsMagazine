using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Orders.Commands;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Orders.CommandsHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public CreateOrderCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<OrderViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Include(x => x.Orders).FirstOrDefaultAsync(x => x.Id == currentUserService.UserId, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var order = user.Orders.FirstOrDefault(x => x.ProductId == request.ProductId);
            if(order == null)
            {
                order = mapper.Map<Order>(request);
                order.UserId = user.Id;
            }
            else
            {
                order.Amount += request.Amount;
            }

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<OrderViewModel>(order);
        }
    }
}

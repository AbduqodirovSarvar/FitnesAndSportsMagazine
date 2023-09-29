using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Orders.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Orders.CommandsHandlers
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, OrderViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        public UpdateOrderCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            order.IsSubmitted = request.IsSubmitted ?? order.IsSubmitted;
            order.Amount = request.Amount ?? order.Amount;

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<OrderViewModel>(order);
        }
    }
}

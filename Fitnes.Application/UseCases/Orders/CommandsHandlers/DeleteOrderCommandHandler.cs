using Fitnes.Application.Interfaces;
using Fitnes.Application.UseCases.Orders.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Orders.CommandsHandlers
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, bool>
    {
        private readonly IAppDbContext context;
        public DeleteOrderCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderID, cancellationToken);
            if(order == null)
            {
                throw new Exception("Order not found");
            }

            context.Orders.Remove(order);

            return (await context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}

using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Orders.Queries;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.UseCases.Orders.QueryHandlers
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        public GetOrderQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return mapper.Map<OrderViewModel>(order);
        }
    }
}

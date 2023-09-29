using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Orders.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Orders.QueryHandlers
{
    public class GetAllOrderQueryHandler : IQueryHandler<GetAllOrderQuery, List<OrderViewModel>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        public GetAllOrderQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<OrderViewModel>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await context.Orders.ToListAsync(cancellationToken);

            if(request?.UserId != null)
            {
                orders = orders.Where(x => x.UserId == request.UserId).ToList();
            }

            if(request?.IsSubmitted != null)
            {
                orders = orders.Where(x => x.IsSubmitted == request.IsSubmitted).ToList();
            }

            return mapper.Map<List<OrderViewModel>>(orders);
        }
    }
}

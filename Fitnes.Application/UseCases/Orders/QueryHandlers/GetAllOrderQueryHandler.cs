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
        public async Task<List<OrderViewModel>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<OrderViewModel>>(await context.Orders.ToListAsync(cancellationToken));
        }
    }
}

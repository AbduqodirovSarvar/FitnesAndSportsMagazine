using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Orders.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Orders.QueryHandlers
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        public GetOrderQueryHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public Task<OrderViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}

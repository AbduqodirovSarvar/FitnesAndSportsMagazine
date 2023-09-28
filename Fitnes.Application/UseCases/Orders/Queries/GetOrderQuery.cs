using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Orders.Queries
{
    public class GetOrderQuery : IQuery<OrderViewModel>
    {
        public GetOrderQuery() { }
    }
}

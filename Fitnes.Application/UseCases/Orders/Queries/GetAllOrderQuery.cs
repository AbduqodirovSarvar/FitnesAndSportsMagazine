using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;

namespace Fitnes.Application.UseCases.Orders.Queries
{
    public class GetAllOrderQuery : IQuery<List<OrderViewModel>>
    {
        public int? UserId { get; set; }
        public bool? IsSubmitted { get; set; }
    }
}

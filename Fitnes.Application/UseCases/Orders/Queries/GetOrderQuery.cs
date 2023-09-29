using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Orders.Queries
{
    public class GetOrderQuery : IQuery<OrderViewModel>
    {
        public GetOrderQuery(int Id)
        {
            OrderId = Id;
        }
        [Required]
        public int OrderId { get; set; }
    }
}

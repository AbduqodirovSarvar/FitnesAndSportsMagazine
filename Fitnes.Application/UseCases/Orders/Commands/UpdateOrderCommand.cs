using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Orders.Commands
{
    public class UpdateOrderCommand : ICommand<OrderViewModel>
    {
        [Required]
        public int OrderId { get; set; }
        public int? Amount { get; set; }
        public bool? IsSubmitted { get; set; }
    }
}

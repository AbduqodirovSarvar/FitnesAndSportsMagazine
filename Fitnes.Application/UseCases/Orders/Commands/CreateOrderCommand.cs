using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : ICommand<OrderViewModel>
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}

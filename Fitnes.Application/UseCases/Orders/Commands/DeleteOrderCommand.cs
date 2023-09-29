using Fitnes.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Orders.Commands
{
    public class DeleteOrderCommand : ICommand<bool>
    {
        public DeleteOrderCommand(int Id)
        {
            OrderID = Id;
        }
        [Required]
        public int OrderID { get; set; }
    }
}

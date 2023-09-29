using Fitnes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

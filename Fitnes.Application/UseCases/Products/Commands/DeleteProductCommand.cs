using Fitnes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fitnes.Application.UseCases.Products.Commands
{
    public class DeleteProductCommand : ICommand<bool>
    {
        public DeleteProductCommand(int Id) 
        {
            ProductId = Id;
        }
        [Required]
        public int ProductId { get; set; }
    }
}

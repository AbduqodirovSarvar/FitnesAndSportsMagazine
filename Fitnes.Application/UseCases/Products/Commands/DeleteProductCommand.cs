using Fitnes.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

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

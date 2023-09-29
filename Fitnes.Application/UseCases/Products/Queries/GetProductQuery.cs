using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Products.Queries
{
    public class GetProductQuery : IQuery<ProductViewModel>
    {
        public GetProductQuery(int Id)
        {
            ProductId = Id;
        }
        [Required]
        public int ProductId { get; set; }
    }
}

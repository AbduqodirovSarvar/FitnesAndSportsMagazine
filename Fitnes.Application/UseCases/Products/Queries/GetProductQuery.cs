using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

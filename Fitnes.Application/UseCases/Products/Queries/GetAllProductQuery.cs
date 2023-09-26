using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Products.Queries
{
    public class GetAllProductQuery : IQuery<List<ProductViewModel>>
    {
        public GetAllProductQuery(ProductType productType)
        {
            this.ProductType = productType;
        }
        private ProductType ProductType { get; set; }

        public ProductType GetProductType()
        { 
            return this.ProductType;
        }
    }
}

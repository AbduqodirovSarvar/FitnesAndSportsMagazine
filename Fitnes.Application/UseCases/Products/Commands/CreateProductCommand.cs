using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Products.Commands
{
    public class CreateProductCommand : ICommand<ProductViewModel>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int Amount { get; set; }
        public IFormFile? Image { get; set; }
        public string Type { get; set; } = string.Empty;

        private ProductType ProductType { get; set; } = ProductType.Product;
        public void SetEquipmentType()
        {
            ProductType = ProductType.Equipment;
        }

        public ProductType GetProductType()
        {
            return ProductType;
        }
    }
}

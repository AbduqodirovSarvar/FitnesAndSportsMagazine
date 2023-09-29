using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Products.Commands
{
    public class UpdateProductCommand : ICommand<ProductViewModel>
    {
        [Required]
        public int ProductId { get; set; }
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
        public double? Price { get; set; } = null;
        public string? Brand { get; set; } = null;
        public int? Amount { get; set; } = null;
        public IFormFile? Image { get; set; } = null;
        public string? Type { get; set; } = null;

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

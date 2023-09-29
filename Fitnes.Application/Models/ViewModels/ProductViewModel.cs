using Fitnes.Domain.Enums;

namespace Fitnes.Application.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string? ImageName { get; set; }
        public ProductType ProductType { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public ICollection<OrderViewModel> Orders { get; set; } = new HashSet<OrderViewModel>();
    }
}

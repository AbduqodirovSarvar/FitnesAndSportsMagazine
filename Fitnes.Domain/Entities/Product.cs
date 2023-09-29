using Fitnes.Domain.Enums;

namespace Fitnes.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string? ImageName { get; set; }
        public ProductType ProductType { get; set; } = ProductType.Product;
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

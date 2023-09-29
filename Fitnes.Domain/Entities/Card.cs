namespace Fitnes.Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

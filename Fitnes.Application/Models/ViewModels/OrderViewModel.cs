namespace Fitnes.Application.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int ConsumerId { get; set; }
        public ConsumerViewModel? Consumer { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
        public int Amount { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

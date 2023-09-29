using Fitnes.Domain.Enums;

namespace Fitnes.Application.Models.ViewModels
{
    public class UserServiceViewModel
    {
        public int ServiceId { get; set; }
        public int ConsumerId { get; set; }
        public ConsumerViewModel? Consumer { get; set; }
        public TypeDays Days { get; set; }
        public double ServicePrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

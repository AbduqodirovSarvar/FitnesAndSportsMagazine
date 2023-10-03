using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;

namespace Fitnes.Application.Models.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly BirthDay { get; set; }
        public string? ImageName { get; set; }
        public int? TeacherId { get; set; }
        public User? Teacher { get; set; }
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        public UserRole Role { get; set; } = UserRole.Consumer;
        public TypeDays? Days { get; set; } = TypeDays.Odd;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Card> Cards { get; set; } = new HashSet<Card>();
        public ICollection<User> Consumers { get; set; } = new HashSet<User>();
    }
}

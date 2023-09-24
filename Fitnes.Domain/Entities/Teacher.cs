using Fitnes.Domain.Enums;

namespace Fitnes.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateOnly BirthDay { get; set; }
        public string? ImagePath { get; set; }
        public TypeDays Days { get; set; } = TypeDays.Odd;
        public DateTime JoinedTime { get; set; } = DateTime.Now;
    }
}
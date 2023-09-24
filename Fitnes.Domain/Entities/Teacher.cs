using Fitnes.Domain.Enums;

namespace Fitnes.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User UserTeacher { get; set; } = null!;
        public TypeDays Days { get; set; } = TypeDays.Odd;
        public DateTime JoinedTime { get; set; } = DateTime.UtcNow;
        public ICollection<Consumer> Consumers { get; set; } = new HashSet<Consumer>();
    }
}
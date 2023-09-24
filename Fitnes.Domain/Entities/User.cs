using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateOnly BirthDay { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public string? ImagePath { get; set; }
        public UserRole Role { get; set; } = UserRole.Consumer;
        public DateTime JoinedTime { get; set; } = DateTime.Now;
    }
}

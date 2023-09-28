using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class AdminViewModel
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly BirthDay { get; set; }
        public string? ImageName { get; set; }
        public UserRole Role { get; set; } = UserRole.Consumer;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

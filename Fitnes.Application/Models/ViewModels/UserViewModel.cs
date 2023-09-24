using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateOnly BirthDay { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public string? ImagePath { get; set; }
        public UserRole Role { get; set; }
        public DateTime JoinedTime { get; set; }
        public ICollection<UserServiceViewModel> Services { get; set; } = new HashSet<UserServiceViewModel>();
        public ICollection<MessageViewModel> Messages { get; set; } = new HashSet<MessageViewModel>();
        public ICollection<OrderViewModel> Orders { get; set; } = new HashSet<OrderViewModel>();
        public ICollection<CardViewModel> Cards { get; set; } = new HashSet<CardViewModel>();
    }
}

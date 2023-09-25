using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class ConsumerViewModel
    {
        public int ConsumerId { get; set; }
        public UserViewModel? User { get; set; }
        public int? TeacherId { get; set; }
        public TeacherViewModel? Teacher { get; set; }
        public DateTime JoinedTime { get; set; }
        public ICollection<ConsumerServiceViewModel> Services { get; set; } = new HashSet<ConsumerServiceViewModel>();
        public ICollection<MessageViewModel> Messages { get; set; } = new HashSet<MessageViewModel>();
        public ICollection<OrderViewModel> Orders { get; set; } = new HashSet<OrderViewModel>();
        public ICollection<CardViewModel> Cards { get; set; } = new HashSet<CardViewModel>();
    }
}

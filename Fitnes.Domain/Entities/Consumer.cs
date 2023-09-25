using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Domain.Entities
{
    public class Consumer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public DateTime JoinedTime { get; set; } = DateTime.UtcNow;
        public ICollection<ConsumerService> Services { get; set; } = new HashSet<ConsumerService>();
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}

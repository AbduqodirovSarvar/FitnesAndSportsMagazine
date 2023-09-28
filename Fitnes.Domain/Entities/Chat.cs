using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Domain.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}

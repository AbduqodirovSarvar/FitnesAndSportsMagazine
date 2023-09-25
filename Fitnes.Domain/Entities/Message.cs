using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int ConsumerId { get; set; }
        public Consumer? Consumer { get; set; }
        public int AdminId { get; set; }
        public Admin? Admin { get; set; }
        public string MsgOrPath { get; set; } = string.Empty;
        public MessageType Type { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

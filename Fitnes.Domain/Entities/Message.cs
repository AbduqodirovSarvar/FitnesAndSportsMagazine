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
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Msg { get; set; } = string.Empty;
        public MessageType Type { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

using Fitnes.Domain.Enums;

namespace Fitnes.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public User? Sender { get; set; }
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }
        public string MsgOrFileName { get; set; } = string.Empty;
        public MessageType Type { get; set; } = MessageType.Text;
        public SendOrReceive Route { get; set; } = SendOrReceive.Send;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

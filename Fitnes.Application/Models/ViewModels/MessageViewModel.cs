using Fitnes.Domain.Enums;

namespace Fitnes.Application.Models.ViewModels
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public int ConsumerId { get; set; }
        public ConsumerViewModel? Consumer { get; set; }
        public int AdminId { get; set; }
        public AdminViewModel? Admin { get; set; }
        public string MsgOrPath { get; set; } = string.Empty;
        public MessageType Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

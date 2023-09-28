using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class ChatViewModel
    {
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public UserViewModel? User { get; set; }
        public ICollection<MessageViewModel> Messages { get; set; } = new HashSet<MessageViewModel>();
        public DateTime CreatedTime { get; set; }
    }
}

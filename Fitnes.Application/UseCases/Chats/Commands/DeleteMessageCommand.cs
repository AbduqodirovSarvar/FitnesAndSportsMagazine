using Fitnes.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Chats.Commands
{
    public class DeleteMessageCommand : ICommand<bool>
    {
        public DeleteMessageCommand(int id)
        {
            MessageId = id;
        }
        [Required]
        public int MessageId { get; set; }
    }
}

using Fitnes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Chats.Commands
{
    public class CreateMessageCommand : ICommand<ChatViewModel>
    {
        [Required]
        public int ChatId { get; set; }
        public string? MsgOrFileName { get; set; }
        [Required]
        public MessageType Type { get; set; } = MessageType.Text;
    }
}

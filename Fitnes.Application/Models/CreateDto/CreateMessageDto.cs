using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.CreateDto
{
    public class CreateMessageDto
    {
        [Required]
        public int ChatId { get; set; }
        public string? Text { get; set; }
        public IFormFile? File { get; set; }
        [Required]
        public MessageType Type { get; set; } = MessageType.Text;
    }
}

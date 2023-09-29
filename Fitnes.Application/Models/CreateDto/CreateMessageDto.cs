using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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

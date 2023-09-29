using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Chats.Queries
{
    public class GetChatQuery : IQuery<ChatViewModel>
    {
        public GetChatQuery(int Id)
        {
            ChatId = Id;
        }
        [Required]
        public int ChatId { get; set; }
    }
}

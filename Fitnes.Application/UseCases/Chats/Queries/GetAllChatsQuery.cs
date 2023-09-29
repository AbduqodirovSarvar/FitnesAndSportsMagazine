using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;

namespace Fitnes.Application.UseCases.Chats.Queries
{
    public class GetAllChatsQuery : IQuery<List<ChatViewModel>>
    {
        public GetAllChatsQuery() { }
    }
}

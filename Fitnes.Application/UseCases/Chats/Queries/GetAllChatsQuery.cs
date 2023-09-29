using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Chats.Queries
{
    public class GetAllChatsQuery : IQuery<List<ChatViewModel>>
    {
        public GetAllChatsQuery() { }
    }
}

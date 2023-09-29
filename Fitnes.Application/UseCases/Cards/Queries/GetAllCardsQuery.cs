using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;

namespace Fitnes.Application.UseCases.Cards.Queries
{
    public class GetAllCardsQuery : IQuery<List<CardViewModel>>
    {
        public GetAllCardsQuery() { }
    }
}

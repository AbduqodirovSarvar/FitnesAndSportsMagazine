using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Cards.Queries
{
    public class GetCardsQuery : IQuery<CardViewModel>
    {
        public GetCardsQuery(int Id)
        {
            CardId = Id;
        }
        [Required]
        public int CardId { get; set; }
    }
}

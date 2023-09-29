using Fitnes.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Cards.Commands
{
    public class DeleteCardsCommand : ICommand<bool>
    {
        public DeleteCardsCommand(int Id)
        {
            CardId = Id;
        }
        [Required]
        public int CardId { get; set; }
    }
}

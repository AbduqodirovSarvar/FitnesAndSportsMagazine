using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Cards.Commands
{
    public class CreateCardsCommand : ICommand<CardViewModel>
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}

using Fitnes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

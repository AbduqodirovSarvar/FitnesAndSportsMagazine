using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fitnes.Application.UseCases.Cards.Commands
{
    public class UpdateCardsCommand : ICommand<CardViewModel>
    {
        [Required]
        public int ProductId { get; set; }
        public int? Amount { get; set; } = null;
    }
}

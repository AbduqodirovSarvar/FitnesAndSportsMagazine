using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

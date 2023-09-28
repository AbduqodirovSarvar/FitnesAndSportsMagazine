using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

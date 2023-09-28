using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Cards.Queries
{
    public class GetAllCardsQuery : IQuery<List<CardViewModel>>
    {
        public GetAllCardsQuery() { }
    }
}

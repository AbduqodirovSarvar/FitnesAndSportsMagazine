using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class CardViewModel
    {
        public int CardId { get; set; }
        public int ConsumerId { get; set; }
        public ConsumerViewModel? Consumer { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

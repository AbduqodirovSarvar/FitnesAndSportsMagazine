using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Orders.Commands
{
    public class UpdateOrderCommand : ICommand<OrderViewModel>
    {
        [Required]
        public int OrderId { get; set; }
        public int? Amount { get; set; }
        public bool? IsSubmitted { get; set; }
    }
}

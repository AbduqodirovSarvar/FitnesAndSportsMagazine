using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fitnes.Application.UseCases.Services.Commands
{
    public class UpdateServiceCommand : ICommand<Service>
    {
        [Required]
        public int ServiceId { get; set; }
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}

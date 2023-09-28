using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Services.Commands
{
    public class CreateServiceCommand : ICommand<Service>
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
    }
}

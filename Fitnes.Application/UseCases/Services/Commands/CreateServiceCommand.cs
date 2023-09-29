using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using System.ComponentModel.DataAnnotations;

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

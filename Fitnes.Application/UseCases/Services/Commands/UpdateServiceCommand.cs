using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using System.ComponentModel.DataAnnotations;

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

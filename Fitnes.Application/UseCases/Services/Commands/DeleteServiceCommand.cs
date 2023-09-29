using Fitnes.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Services.Commands
{
    public class DeleteServiceCommand : ICommand<bool>
    {
        public DeleteServiceCommand(int Id)
        {
            ServiceId = Id;
        }
        [Required]
        public int ServiceId { get; set; }
    }
}

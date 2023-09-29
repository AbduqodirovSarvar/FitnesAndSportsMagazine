using Fitnes.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Authorize.Commands
{
    public class ResetPasswordCommand : ICommand<bool>
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; } = null!;
    }
}

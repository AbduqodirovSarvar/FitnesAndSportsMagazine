using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Authorize.Commands
{
    public class LoginCommand : ICommand<LoginViewModel>
    {
        [Required]
        public string EmailOrPhone { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}

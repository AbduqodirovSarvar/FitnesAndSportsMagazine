using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

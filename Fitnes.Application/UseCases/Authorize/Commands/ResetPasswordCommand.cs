using Fitnes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

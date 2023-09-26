using Fitnes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fitnes.Application.UseCases.Users.Commands
{
    public class DeleteUserCommand : ICommand<bool>
    {
        [Required]
        public int UserId { get; set; }
    }
}

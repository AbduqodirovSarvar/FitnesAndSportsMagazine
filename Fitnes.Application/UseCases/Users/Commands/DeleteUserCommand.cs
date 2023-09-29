using Fitnes.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Users.Commands
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public DeleteUserCommand(int Id)
        {
            UserId = Id;
        }
        [Required]
        public int UserId { get; set; }
    }
}

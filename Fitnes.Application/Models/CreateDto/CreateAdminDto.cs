using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Users.Commands
{
    public class CreateAdminDto : ICommand<AdminViewModel>
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public DateOnly BirthDay { get; set; }
        public IFormFile? Image { get; set; }
    }
}

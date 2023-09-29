using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Users.Commands
{
    public class CreateTeacherDto : ICommand<TeacherViewModel>
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
        [Required]
        public TypeDays Days { get; set; }
        public IFormFile? Image { get; set; }
    }
}

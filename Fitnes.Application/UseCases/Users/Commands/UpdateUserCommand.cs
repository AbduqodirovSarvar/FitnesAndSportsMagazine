using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : ICommand<User>
    {
        [Required]
        public int Id { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Phone { get; set; } = null;
        public DateOnly? BirthDay { get; set; } = null;
        public IFormFile? Image { get; set; } = null;
        public int? TeacherId { get; set; } = null;
        public TypeDays? Days { get; set; } = null;
        public int? ServiceId { get; set; } = null;
    }
}

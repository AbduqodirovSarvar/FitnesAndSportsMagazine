﻿using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Users.Commands
{
    public class CreateUserCommand : ICommand<User>
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
        public int? TeacherId { get; set; }
        public TypeDays? Days { get; set; } = TypeDays.Odd;
        public int? ServiceId { get; set; }
        public UserRole? Role { get; set; } = UserRole.Consumer;
    }
}

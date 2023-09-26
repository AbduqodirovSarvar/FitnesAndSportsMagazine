using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Users.Commands
{
    public class UpdateAdminCommand : ICommand<AdminViewModel>
    {
        [Required]
        public int AdminId { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Phone { get; set; } = null;
        public string? Password { get; set; } = null;
        public DateOnly? BirthDay { get; set; } = null;
        public IFormFile? Image { get; set; } = null;
    }
}

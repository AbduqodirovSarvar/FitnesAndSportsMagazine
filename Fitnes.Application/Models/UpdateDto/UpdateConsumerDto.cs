using Fitnes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.UpdateDto
{
    public class UpdateConsumerDto
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

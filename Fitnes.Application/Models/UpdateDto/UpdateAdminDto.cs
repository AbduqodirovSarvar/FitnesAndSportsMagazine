using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.Models.UpdateDto
{
    public class UpdateAdminDto
    {
        [Required]
        public int Id { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Phone { get; set; } = null;
        public DateOnly? BirthDay { get; set; } = null;
        public IFormFile? Image { get; set; } = null;
    }
}

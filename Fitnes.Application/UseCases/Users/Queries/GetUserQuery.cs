using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Users.Queries
{
    public class GetUserQuery : IQuery<User>
    {
        public GetUserQuery(int UserId)
        {
            this.UserId = UserId;
        }
        [Required]
        public int UserId { get; set; }
    }
}

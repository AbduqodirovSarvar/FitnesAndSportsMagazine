using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

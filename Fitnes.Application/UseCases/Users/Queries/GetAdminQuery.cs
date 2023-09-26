using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Users.Queries
{
    public class GetAdminQuery : IQuery<AdminViewModel>
    {
        public GetAdminQuery(int AdminId) 
        {
            this.AdminId = AdminId; 
        }
        [Required]
        public int AdminId { get; set; }
    }
}

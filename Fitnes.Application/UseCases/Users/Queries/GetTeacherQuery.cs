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
    public class GetTeacherQuery : IQuery<TeacherViewModel>
    {
        public GetTeacherQuery(int TeacherId) 
        {
            this.TeacherId = TeacherId;
        }
        [Required]
        public int TeacherId { get; set; }
    }
}

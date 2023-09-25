using Fitnes.Domain.Entities;
using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public UserViewModel? UserTeacher { get; set; }
        public TypeDays Days { get; set; }
        public DateTime JoinedTime { get; set; }
        public ICollection<ConsumerViewModel> Consumers { get; set; } = new HashSet<ConsumerViewModel>();
    }
}

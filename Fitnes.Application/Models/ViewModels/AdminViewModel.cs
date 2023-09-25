using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Models.ViewModels
{
    public class AdminViewModel
    {
        public int AdminId { get; set; }
        public UserViewModel? User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

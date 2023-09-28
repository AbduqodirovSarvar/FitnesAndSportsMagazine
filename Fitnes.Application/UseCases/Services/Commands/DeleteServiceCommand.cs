using Fitnes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Services.Commands
{
    public class DeleteServiceCommand : ICommand<bool>
    {
        public DeleteServiceCommand(int Id) 
        {
            ServiceId = Id;
        }
        [Required]
        public int ServiceId { get; set; }
    }
}

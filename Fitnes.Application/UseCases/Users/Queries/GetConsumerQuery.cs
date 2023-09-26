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
    public class GetConsumerQuery : IQuery<ConsumerViewModel>
    {
        public GetConsumerQuery(int ConsumerId) 
        {
            this.ConsumerId = ConsumerId;
        }
        [Required]
        public int ConsumerId { get; set; }
    }
}

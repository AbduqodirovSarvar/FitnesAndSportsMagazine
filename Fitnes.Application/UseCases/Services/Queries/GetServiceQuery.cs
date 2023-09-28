using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Services.Queries
{
    public class GetServiceQuery : IQuery<Service>
    {
        public GetServiceQuery(int Id )
        {
            ServiceId = Id;
        }
        [Required]
        public int ServiceId { get; set; }
    }
}

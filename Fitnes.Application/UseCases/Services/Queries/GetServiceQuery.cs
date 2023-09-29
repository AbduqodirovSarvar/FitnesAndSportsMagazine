using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Fitnes.Application.UseCases.Services.Queries
{
    public class GetServiceQuery : IQuery<Service>
    {
        public GetServiceQuery(int Id)
        {
            ServiceId = Id;
        }
        [Required]
        public int ServiceId { get; set; }
    }
}

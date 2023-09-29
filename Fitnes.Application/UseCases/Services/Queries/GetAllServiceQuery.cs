using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;

namespace Fitnes.Application.UseCases.Services.Queries
{
    public class GetAllServiceQuery : IQuery<List<Service>>
    {
        public GetAllServiceQuery() { }
    }
}

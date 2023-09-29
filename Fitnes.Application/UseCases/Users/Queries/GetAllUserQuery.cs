using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;

namespace Fitnes.Application.UseCases.Users.Queries
{
    public class GetAllUserQuery : IQuery<List<User>>
    {
        public GetAllUserQuery() { }
    }
}

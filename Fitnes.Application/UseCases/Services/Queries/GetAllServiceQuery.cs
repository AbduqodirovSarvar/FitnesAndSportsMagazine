using Fitnes.Application.Interfaces;
using Fitnes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Services.Queries
{
    public class GetAllServiceQuery : IQuery<List<Service>>
    {
        public GetAllServiceQuery() { }
    }
}

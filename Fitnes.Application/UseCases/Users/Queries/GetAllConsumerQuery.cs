﻿using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Users.Queries
{
    public class GetAllConsumerQuery : IQuery<List<ConsumerViewModel>>
    {
        public GetAllConsumerQuery() { }
    }
}

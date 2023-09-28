﻿using Fitnes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Domain.Entities
{
    public class UserService
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public TypeDays Days { get; set; } = TypeDays.Odd;
        public double ServicePrice { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMonths(1);
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}

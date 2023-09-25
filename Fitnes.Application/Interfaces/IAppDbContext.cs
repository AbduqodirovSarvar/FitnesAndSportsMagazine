using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Product> Products { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<ConsumerService> Services { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Card> Cards { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}

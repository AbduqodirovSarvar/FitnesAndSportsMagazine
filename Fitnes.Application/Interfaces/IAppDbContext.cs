using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fitnes.Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<UserService> UserServices { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Card> Cards { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}

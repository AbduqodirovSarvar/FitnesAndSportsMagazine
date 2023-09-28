using Fitnes.Application.Interfaces;
using Fitnes.Application.Services;
using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.EntityTypeConfiguration
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IHashService hashService = new HashService();
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();
            builder.HasMany(x => x.Orders).WithOne().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Services).WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Messages).WithOne().HasForeignKey(x => x.SenderId);
            builder.HasMany(x => x.Cards).WithOne().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Chat).WithOne(x => x.User).HasForeignKey<Chat>(x => x.UserId);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Consumers).HasForeignKey(x => x.TeacherId);
            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Adminjon",
                LastName = "Adminjonov",
                BirthDay = new DateOnly(2002, 03, 16),
                PasswordHash = hashService.GetHash("12345"),
                Phone = "+998932340316",
                Email = "abduqodirovsarvar.2002@gmail.com",
                Role = Domain.Enums.UserRole.Admin,
            });
        }
    }
}

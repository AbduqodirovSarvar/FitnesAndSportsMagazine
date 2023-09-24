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
            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                BirthDay = new DateOnly(2002, 03, 16),
                PasswordHash = hashService.GetHash("12345678"),
                Phone = "+998932340316",
                Email = "abduqodirovsarvar.2002@gmail.com",
            });
        }
    }
}

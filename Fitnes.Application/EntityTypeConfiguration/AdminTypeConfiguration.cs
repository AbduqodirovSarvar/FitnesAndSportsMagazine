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
    public class AdminTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasIndex(x => x.UserId).IsUnique();
            builder.HasOne(x => x.User).WithOne().HasForeignKey<Admin>(x => x.UserId);
            builder.HasData(new Admin
            {
                Id = 1,
                UserId = 1
            });
        }
    }
}

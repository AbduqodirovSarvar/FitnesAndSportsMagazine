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
    public class ConsumerTypeConfiguration : IEntityTypeConfiguration<Consumer>
    {
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.HasMany(x => x.Orders).WithOne().HasForeignKey(x => x.ConsumerId);
            builder.HasMany(x => x.Services).WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Messages).WithOne().HasForeignKey(x => x.FromUserId);
            builder.HasMany(x => x.Cards).WithOne().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Consumers).HasForeignKey(x => x.TeacherId);
        }
    }
}

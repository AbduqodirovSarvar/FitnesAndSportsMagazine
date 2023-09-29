using Fitnes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitnes.Application.EntityTypeConfiguration
{
    public class MessageTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(x => x.Chat).WithMany(x => x.Messages).HasForeignKey(x => x.ChatId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Sender).WithMany(x => x.Messages).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

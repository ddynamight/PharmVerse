using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Invites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Persistence.Invites.Configurations
{
    public class InviteEntityTypeConfiguration : IEntityTypeConfiguration<Invite>
    {
        public void Configure(EntityTypeBuilder<Invite> builder)
        {
            builder.ToTable("Invites");

            builder.HasKey(i => i.AppUserId);
            builder.HasKey(i => i.Id);
            builder.Ignore(i => i.DomainEvents);

            builder.Property(i => i.RowVersion).IsRowVersion();
        }
    }
}

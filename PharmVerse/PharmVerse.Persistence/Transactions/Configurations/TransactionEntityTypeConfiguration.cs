using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Persistence.Transactions.Configurations
{
    public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(t => t.AppUserId);
            builder.HasKey(t => t.Id);
            builder.Ignore(t => t.DomainEvents);

            builder.Property(t => t.Amount)
                .HasColumnType("money");

            builder.Property(t => t.RowVersion).IsRowVersion();

            

        }
    }
}

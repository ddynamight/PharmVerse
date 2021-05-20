using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Wallets;

namespace PharmVerse.Persistence.Wallets.Configurations
{
     public class HistoryEntityTypeConfiguration : IEntityTypeConfiguration<WalletHistory>
     {
          public void Configure(EntityTypeBuilder<WalletHistory> builder)
          {
               builder.ToTable("WalletHistories");

               builder.HasKey(w => w.Id);
               builder.Ignore(w => w.DomainEvents);

               builder.Property(wh => wh.Amount)
                    .HasColumnType("money");

               builder.Property(w => w.RowVersion).IsRowVersion();
          }
     }
}

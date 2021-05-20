using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Wallets;

namespace PharmVerse.Persistence.Wallets.Configurations
{
     public class WalletEntityTypeConfiguration : IEntityTypeConfiguration<Wallet>
     {
          public void Configure(EntityTypeBuilder<Wallet> builder)
          {
               builder.ToTable("Wallets");

               builder.HasKey(w => w.Id);
               builder.Ignore(w => w.DomainEvents);

               builder.Property(w => w.Balance)
                    .HasColumnType("money");


               builder.Property(w => w.RowVersion).IsRowVersion();


               // One to Many Relationships Configuration
               builder.HasMany(w => w.Histories)
                    .WithOne(h => h.Wallet)
                    .HasForeignKey(h => h.WalletAppUserId);
          }
     }
}

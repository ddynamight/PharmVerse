using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Users;
using PharmVerse.Domain.Wallets;

namespace PharmVerse.Persistence.Users.Configurations
{
     public class UserEntityTypeConfiguration : IEntityTypeConfiguration<AppUser>
     {
          public void Configure(EntityTypeBuilder<AppUser> builder)
          {
               builder.ToTable("AppUser");

               builder.HasKey(a => a.Id);
               builder.Ignore(a => a.DomainEvents);


               // One to Zero or One Relationships Configurations


               //builder.HasOne(a => a.Staff)
               //     .WithOne(s => s.AppUser);


               // One to One Relationships

               builder.HasOne(a => a.Setting)
                    .WithOne(s => s.AppUser)
                    .HasForeignKey<Setting>(s => s.AppUserId);

               builder.HasOne(a => a.Wallet)
                    .WithOne(w => w.AppUser)
                    .HasForeignKey<Wallet>(i => i.AppUserId);



               // One to Many Relationships Configurations

               builder.HasMany(u => u.Invites)
                    .WithOne(b => b.AppUser)
                    .HasForeignKey(b => b.AppUserId);


               builder.HasMany(a => a.Notifications)
                    .WithOne(n => n.AppUser)
                    .HasForeignKey(n => n.AppUserId);

               builder.HasMany(u => u.Reviews)
                    .WithOne(r => r.AppUser)
                    .HasForeignKey(r => r.AppUserId);

               builder.HasMany(u => u.Transactions)
                    .WithOne(t => t.AppUser)
                    .HasForeignKey(t => t.AppUserId);
          }

     }
}

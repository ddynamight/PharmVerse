using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PharmVerse.Persistence.Users.Configurations
{
     public class IdentityUserLoginEntityTypesConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
     {
          public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
          {
               builder.ToTable("AspNetUserLogin");
               builder.HasKey(i => i.UserId);
          }
     }

     public class IdentityUserRoleEntityTypesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
     {
          public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
          {
               builder.ToTable("AspNetUserRole");
               builder.HasKey(i => new { i.RoleId, i.UserId });
          }
     }

     public class IdentityRoleEntityTypesConfiguration : IEntityTypeConfiguration<IdentityRole<string>>
     {
          public void Configure(EntityTypeBuilder<IdentityRole<string>> builder)
          {
               builder.ToTable("AspNetRole");
               builder.HasKey(i => i.Id);
          }
     }

     public class IdentityRoleClaimEntityTypesConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
     {
          public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
          {
               builder.ToTable("AspNetRoleClaim");
               builder.HasKey(i => i.Id);
          }
     }

     public class IdentityUserClaimEntityTypesConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
     {
          public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
          {
               builder.ToTable("AspNetUserClaim");
               builder.HasKey(i => i.Id);
          }
     }

     public class IdentityUserTokenEntityTypesConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
     {
          public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
          {
               builder.ToTable("AspNetUserToken");
               builder.HasKey(i => i.UserId);
          }
     }
}

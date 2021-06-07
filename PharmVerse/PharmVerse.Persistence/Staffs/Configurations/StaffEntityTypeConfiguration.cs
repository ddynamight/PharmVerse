using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Persistence.Staffs.Configurations
{
    public class StaffEntityTypeConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staffs");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName);
            builder.Property(s => s.MiddleName);
            builder.Property(s => s.LastName);
            builder.Property(s => s.Image);
            builder.Property(s => s.Address);
            builder.Property(s => s.City);
            builder.Property(s => s.State);
            builder.Property(s => s.Country);
            builder.Property(s => s.Email);
            builder.Property(s => s.Phone);
            builder.Property(s => s.Created);
            builder.Property(s => s.LastOnline);


            builder.Ignore(s => s.DomainEvents);
            builder.Property(s => s.RowVersion).IsRowVersion();
        }
    }
}

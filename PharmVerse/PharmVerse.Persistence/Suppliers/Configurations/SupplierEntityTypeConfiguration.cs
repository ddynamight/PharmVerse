using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Persistence.Suppliers.Configurations
{
    public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.CompanyName);
            builder.Property(s => s.Address);
            builder.Property(s => s.City);
            builder.Property(s => s.State);
            builder.Property(s => s.Country);
            builder.Property(s => s.Contact);
            builder.Property(s => s.Email);
            builder.Property(s => s.Created);

            builder.Ignore(s => s.DomainEvents);
            builder.Property(s => s.RowVersion).IsRowVersion();
        }
    }
}

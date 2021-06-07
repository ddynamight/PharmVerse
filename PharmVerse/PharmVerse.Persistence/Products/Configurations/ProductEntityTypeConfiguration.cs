using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Persistence.Products.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Price);
            builder.Property(p => p.Stock);
            builder.Property(p => p.Created);
            builder.Property(p => p.Category);

            builder.Ignore(p => p.DomainEvents);
            builder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Persistence.Stocks.Configurations
{
    public class StockEntityTypeConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.ProductName);
            builder.Property(s => s.Unit);
            builder.Property(s => s.Price);
            builder.Property(s => s.SalesPrice);
            builder.Property(s => s.Quantity);
            builder.Property(s => s.RestockUnit);
            builder.Property(s => s.StockDate);
            builder.Property(s => s.LastRestockDate);

            builder.Ignore(s => s.DomainEvents);
            builder.Property(s => s.RowVersion).IsRowVersion();

        }
    }
}

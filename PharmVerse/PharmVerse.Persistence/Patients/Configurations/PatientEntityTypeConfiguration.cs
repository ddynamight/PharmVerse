using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmVerse.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Persistence.Patients.Configurations
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName);
            builder.Property(p => p.MiddleName);
            builder.Property(p => p.LastName);
            builder.Property(p => p.Image);
            builder.Property(p => p.Address);
            builder.Property(p => p.City);
            builder.Property(p => p.State);
            builder.Property(p => p.Country);
            builder.Property(p => p.DoctorsInCharge);
            builder.Property(p => p.Alliment);
            builder.Property(p => p.Created);
            builder.Property(p => p.LastOnline);

            builder.Ignore(p => p.DomainEvents);
            builder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}

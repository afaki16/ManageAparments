using ManageApartments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ManageApartments.Domain.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            builder.ToTable("Invoices");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeratorNo);
            builder.Property(x => x.ContractNo);
            builder.Property(x => x.Description);
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasMany(x => x.InvoiceDetails).WithOne(x => x.Invoice).HasForeignKey(x => x.InvoiceId);

        }

       
       
        
      
    }
}
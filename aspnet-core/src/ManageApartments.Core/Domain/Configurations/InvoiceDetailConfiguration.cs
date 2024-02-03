using ManageApartments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ManageApartments.Domain.Configurations
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {

            builder.ToTable("InvoiceDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.InvoiceDate);
            builder.Property(x => x.Description);
            builder.Property(x => x.IsPaid).IsRequired();    
            builder.Property(x => x.RowVersion).IsRowVersion();


        }

       
    }
}
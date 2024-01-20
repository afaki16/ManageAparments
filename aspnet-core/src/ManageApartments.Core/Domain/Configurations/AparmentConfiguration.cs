﻿using ManageApartments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageApartments.Domain.Configurations
  
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {

            builder.ToTable("Apartments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.BlokNo);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasMany(x => x.Invoices).WithOne(x => x.Apartment).HasForeignKey(x => x.ApartmentId);
            builder.HasOne(x => x.Hirer).WithOne(x => x.Apartment).HasForeignKey<Hirer>(x => x.Id);
          

        }
        
    }
}
using ManageApartments.Domain.Entities;
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
            builder.Property(x => x.Description);
            builder.Property(x => x.RoofNo);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasMany(x => x.Hirers).WithOne(x => x.Apartment).HasForeignKey(x => x.ApartmentId);
            builder.HasMany(x => x.Fees).WithOne(x => x.Apartment).HasForeignKey(x => x.ApartmentId);
            builder.HasMany(x => x.Electrics).WithOne(x => x.Apartment).HasForeignKey(x => x.ApartmentId);
            builder.HasMany(x => x.Rents).WithOne(x => x.Apartment).HasForeignKey(x => x.ApartmentId);
          

        }
        
    }
}
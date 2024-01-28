using ManageApartments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageApartments.Domain.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {

            builder.ToTable("Buildings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasMany(x => x.Apartments).WithOne(x => x.Building).HasForeignKey(x => x.BuildingId);
            builder.HasMany(x => x.Expenses).WithOne(x => x.Building).HasForeignKey(x => x.BuildingId);


        }
    }
}
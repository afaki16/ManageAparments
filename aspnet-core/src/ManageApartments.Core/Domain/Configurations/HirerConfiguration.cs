using ManageApartments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ManageApartments.Domain.Configurations
{
    public class HirerConfiguration : IEntityTypeConfiguration<Hirer>
    {
        public void Configure(EntityTypeBuilder<Hirer> builder)
        {

            builder.ToTable("Hirers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SSN).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.IsActive);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.UsageTime);
            builder.Property(x => x.Description);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasMany(x => x.InvoiceDetails).WithOne(x => x.Hirer).HasForeignKey(x => x.HirerId);

        }

       
    }
}
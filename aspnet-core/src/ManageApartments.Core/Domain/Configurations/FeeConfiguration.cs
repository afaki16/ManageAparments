using ManageApartments.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Configurations
{
    public class FeeConfiguration : IEntityTypeConfiguration<Fee>
    {
        public void Configure(EntityTypeBuilder<Fee> builder)
        {

            builder.ToTable("Fees");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.IsActive);
            builder.Property(x => x.RowVersion).IsRowVersion();

        }
    }
}

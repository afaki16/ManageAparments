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
    public class ElectricConfiguration : IEntityTypeConfiguration<Electric>
    {
        public void Configure(EntityTypeBuilder<Electric> builder)
        {

            builder.ToTable("Electrics");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeratorNo).IsRequired();
            builder.Property(x => x.StaticKW);
            builder.Property(x => x.KW);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.RowVersion).IsRowVersion();

        }
    }
   
}

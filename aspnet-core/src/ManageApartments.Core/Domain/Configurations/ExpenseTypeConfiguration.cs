using ManageApartments.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageApartments.Domain.Entities;

namespace ManageApartments.Domain.Configurations
{
    public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {

            builder.ToTable("ExpenseTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasMany(x => x.Expenses).WithOne(x => x.ExpenseType).HasForeignKey(x => x.ExpenseTypeId);
            

    }
    }
}

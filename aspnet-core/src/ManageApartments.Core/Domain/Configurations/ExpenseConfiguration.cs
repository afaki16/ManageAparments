using ManageApartments.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageApartments.Domain.Entites;

namespace ManageApartments.Domain.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {

            builder.ToTable("Expenses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.PriceDate);
            builder.Property(x => x.RowVersion).IsRowVersion();

    }
    }
}

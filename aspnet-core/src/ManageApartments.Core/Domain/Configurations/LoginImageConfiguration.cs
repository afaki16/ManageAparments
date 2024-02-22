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
    public class LoginImageConfiguration : IEntityTypeConfiguration<LoginImage>
    {
        public void Configure(EntityTypeBuilder<LoginImage> builder)
        {
            builder.ToTable("LoginImages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PhotoUrl).HasMaxLength(1024);
        }
    }
}

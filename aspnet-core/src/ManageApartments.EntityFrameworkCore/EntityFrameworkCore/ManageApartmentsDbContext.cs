using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ManageApartments.Authorization.Roles;
using ManageApartments.Authorization.Users;
using ManageApartments.MultiTenancy;
using ManageApartments.Domain.Entities;
using ManageApartments.Domain.Configurations;

namespace ManageApartments.EntityFrameworkCore
{
    public class ManageApartmentsDbContext : AbpZeroDbContext<Tenant, Role, User, ManageApartmentsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Hirer> Hirers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public ManageApartmentsDbContext(DbContextOptions<ManageApartmentsDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BuildingConfiguration())
                .ApplyConfiguration(new ApartmentConfiguration())
                .ApplyConfiguration(new HirerConfiguration())
                .ApplyConfiguration(new InvoiceConfiguration())
                .ApplyConfiguration(new InvoiceDetailConfiguration());

        }
    }
}

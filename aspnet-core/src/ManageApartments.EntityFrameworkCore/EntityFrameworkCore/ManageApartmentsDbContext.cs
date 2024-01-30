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
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Electric> Electrics { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Rent> Rents { get; set; }

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
                .ApplyConfiguration(new InvoiceDetailConfiguration())
                .ApplyConfiguration(new ElectricConfiguration())
                .ApplyConfiguration(new FeeConfiguration())
                .ApplyConfiguration(new RentConfiguration())
                .ApplyConfiguration(new ExpenseConfiguration())
                .ApplyConfiguration(new ExpenseTypeConfiguration());

        }
    }
}

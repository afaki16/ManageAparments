using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ManageApartments.EntityFrameworkCore
{
    public static class ManageApartmentsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ManageApartmentsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ManageApartmentsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

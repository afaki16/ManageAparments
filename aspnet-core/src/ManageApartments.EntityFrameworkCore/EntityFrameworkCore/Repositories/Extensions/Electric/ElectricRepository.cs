using Abp.EntityFrameworkCore;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Electric;


namespace ManageApartments.EntityFrameworkCore.Repositories.Extensions.Electric
{
    public class ElectricRepository : ManageApartmentsRepositoryBase<Domain.Entities.Electric, int>, IElectricRepository
    {
        public ElectricRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

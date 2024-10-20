using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;


namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Hirer
{
    public class HirerRepository : ManageApartmentsRepositoryBase<Domain.Entities.Hirer, int>, IHirerRepository
    {
        public HirerRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

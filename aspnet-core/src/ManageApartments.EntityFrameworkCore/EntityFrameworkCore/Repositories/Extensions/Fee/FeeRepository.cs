using Abp.EntityFrameworkCore;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Fee;


namespace ManageApartments.EntityFrameworkCore.Repositories.Extensions.Fee
{
    public class FeeRepository : ManageApartmentsRepositoryBase<Domain.Entities.Fee, int>, IFeeRepository
    {
        public FeeRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

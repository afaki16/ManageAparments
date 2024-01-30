using Abp.EntityFrameworkCore;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Rent;


namespace ManageApartments.EntityFrameworkCore.Repositories.Extensions.Rent
{
    public class RentRepository : ManageApartmentsRepositoryBase<Domain.Entities.Rent, int>, IRentRepository
    {
        public RentRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

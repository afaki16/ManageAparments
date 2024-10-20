using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;


namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Apartment
{
    public class ApartmentRepository : ManageApartmentsRepositoryBase<Domain.Entities.Apartment, int>, IApartmentRepository
    {
        public ApartmentRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

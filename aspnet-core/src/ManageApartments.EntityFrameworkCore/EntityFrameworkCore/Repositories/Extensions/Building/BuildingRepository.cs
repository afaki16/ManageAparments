using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;


namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Building
{
    public class BuildingRepository : ManageApartmentsRepositoryBase<Domain.Entities.Building, int>, IBuildingRepository
    {
        public BuildingRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

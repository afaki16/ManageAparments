using Abp.Domain.Repositories;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Electric
{
    public interface IElectricRepository : IRepository<Domain.Entities.Electric, int>
    {
    }
}

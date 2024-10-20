using Abp.Domain.Repositories;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Rent
{
    public interface IRentRepository : IRepository<Domain.Entities.Rent, int>
    {
    }
}

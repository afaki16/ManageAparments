using Abp.Domain.Repositories;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Hirer
{
    public interface IHirerRepository : IRepository<Domain.Entities.Hirer, int>
    {

    }
}

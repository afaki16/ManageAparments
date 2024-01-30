using Abp.Domain.Repositories;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Fee
{
    public interface IFeeRepository : IRepository<Domain.Entities.Fee, int>
    {
    }
}

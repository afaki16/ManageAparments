using Abp.Domain.Repositories;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Apartment
{
    public interface IApartmentRepository : IRepository<Domain.Entities.Apartment, int>
    {

    }
}

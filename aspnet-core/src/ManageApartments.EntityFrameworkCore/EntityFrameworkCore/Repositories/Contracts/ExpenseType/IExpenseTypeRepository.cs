using Abp.Domain.Repositories;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.ExpenseType
{
    public interface IExpenseTypeRepository : IRepository<Domain.Entities.ExpenseType, int>
    {
    }
}

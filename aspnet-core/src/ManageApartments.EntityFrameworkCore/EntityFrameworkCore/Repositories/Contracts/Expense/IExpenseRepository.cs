using Abp.Domain.Repositories;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Expense
{
    public interface IExpenseRepository : IRepository<Domain.Entities.Expense, int>
    {
    }
}

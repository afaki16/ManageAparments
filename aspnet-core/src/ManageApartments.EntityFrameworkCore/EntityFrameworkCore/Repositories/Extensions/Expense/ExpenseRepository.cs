using Abp.EntityFrameworkCore;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Expense;


namespace ManageApartments.EntityFrameworkCore.Repositories.Extensions.Expense
{
    public class ExpenseRepository : ManageApartmentsRepositoryBase<Domain.Entities.Expense, int>, IExpenseRepository
    {
        public ExpenseRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

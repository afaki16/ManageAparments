using Abp.EntityFrameworkCore;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.ExpenseType;


namespace ManageApartments.EntityFrameworkCore.Repositories.Extensions.ExpenseType
{
    public class ExpenseTypeRepository : ManageApartmentsRepositoryBase<Domain.Entities.ExpenseType, int>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

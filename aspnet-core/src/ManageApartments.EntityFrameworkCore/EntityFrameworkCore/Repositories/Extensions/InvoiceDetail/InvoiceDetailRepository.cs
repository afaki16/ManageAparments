using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;


namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.InvoiceDetail
{
    public class InvoiceDetailRepository : ManageApartmentsRepositoryBase<Domain.Entities.InvoiceDetail, int>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

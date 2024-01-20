using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;


namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Invoice
{
    public class InvoiceRepository : ManageApartmentsRepositoryBase<Domain.Entities.Invoice, int>, IInvoiceRepository
    {
        public InvoiceRepository(IDbContextProvider<ManageApartmentsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}

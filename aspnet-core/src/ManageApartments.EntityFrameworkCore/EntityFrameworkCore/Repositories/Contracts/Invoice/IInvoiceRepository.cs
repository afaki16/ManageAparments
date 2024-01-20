using Abp.Domain.Repositories;

namespace ManageApartments.EntityFrameworkCore.Repositories.Contracts.Invoice
{
    public interface IInvoiceRepository : IRepository<Domain.Entities.Invoice, int>
    {

    }
}

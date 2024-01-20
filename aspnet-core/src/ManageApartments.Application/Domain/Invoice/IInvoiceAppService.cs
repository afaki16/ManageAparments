using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeNG.TableFilter.Models;
using ManageApartments.Domain.Invoice.Dtos;

namespace ManageApartments.Domain.Invoice
{

    public interface IInvoiceAppService : IAsyncCrudAppService<InvoiceFullOutput, int, GetInvoiceListInput, CreateInvoiceInput,
    UpdateInvoiceInput, GetInvoiceInput, DeleteInvoiceInput>
    {
        Task<PagedResultDto<InvoiceFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);
   
    }
}

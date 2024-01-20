using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeNG.TableFilter.Models;
using ManageApartments.Domain.InvoiceDetail.Dtos;

namespace ManageApartments.Domain.InvoiceDetail
{

    public interface IInvoiceDetailAppService : IAsyncCrudAppService<InvoiceDetailFullOutput, int, GetInvoiceDetailListInput, CreateInvoiceDetailInput,
    UpdateInvoiceDetailInput, GetInvoiceDetailInput, DeleteInvoiceDetailInput>
    {
        Task<PagedResultDto<InvoiceDetailFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);
   
    }
}

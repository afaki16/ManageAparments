using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ManageApartments.Authorization;
using ManageApartments.Domain.Invoice.Dtos;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Invoice;

namespace ManageApartments.Domain.Invoice;

[AbpAuthorize(PermissionNames.Invoice)]

public class InvoiceAppService :
    AsyncCrudAppService<Entities.Invoice, InvoiceFullOutput, int, GetInvoiceListInput, CreateInvoiceInput, UpdateInvoiceInput,
        GetInvoiceInput, DeleteInvoiceInput>, IInvoiceAppService
{
    private readonly IInvoiceRepository _invoiceRepository;


    public InvoiceAppService(IInvoiceRepository invoiceRepository) : base(invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;

    }

    [HttpPost]
    public async Task<PagedResultDto<InvoiceFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._invoiceRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<InvoiceFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<InvoiceFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<InvoiceFullOutput> CreateAsync(CreateInvoiceInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<InvoiceFullOutput> UpdateAsync(UpdateInvoiceInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteInvoiceInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }


}

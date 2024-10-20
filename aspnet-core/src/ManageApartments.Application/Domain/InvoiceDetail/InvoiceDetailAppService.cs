﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ManageApartments.Authorization;
using ManageApartments.Domain.InvoiceDetail.Dtos;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.InvoiceDetail;
using Microsoft.EntityFrameworkCore;
using ManageApartments.Domain.Hirer.Dtos;
using System.Linq.Dynamic.Core;

namespace ManageApartments.Domain.InvoiceDetail;

[AbpAuthorize(PermissionNames.InvoiceDetail)]

public class InvoiceDetailAppService :
    AsyncCrudAppService<Entities.InvoiceDetail, InvoiceDetailFullOutput, int, GetInvoiceDetailListInput, CreateInvoiceDetailInput, UpdateInvoiceDetailInput,
        GetInvoiceDetailInput, DeleteInvoiceDetailInput>, IInvoiceDetailAppService
{
    private readonly IInvoiceDetailRepository _invoiceDetailRepository;


    public InvoiceDetailAppService(IInvoiceDetailRepository invoiceDetailRepository) : base(invoiceDetailRepository)
    {
        _invoiceDetailRepository = invoiceDetailRepository;

    }

    [HttpPost]
    public async Task<PagedResultDto<InvoiceDetailFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._invoiceDetailRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        query = query.Include(x => x.Hirer).ThenInclude(x=>x.Apartment);
           
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<InvoiceDetailFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<InvoiceDetailFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<InvoiceDetailFullOutput> CreateAsync(CreateInvoiceDetailInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<InvoiceDetailFullOutput> UpdateAsync(UpdateInvoiceDetailInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteInvoiceDetailInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }

    [HttpGet]
    public async Task<List<InvoiceDetailFullOutput>> GetAllPayment()
    {
        var query = this._invoiceDetailRepository.GetAll().Include(x => x.Hirer).ThenInclude(x=>x.Apartment).Where(x=>x.IsPaid ==false).OrderBy(x => x.InvoiceDate).ToListAsync();
        return this.ObjectMapper.Map<List<InvoiceDetailFullOutput>>(await query);
    }

    [HttpGet]
    public async Task<List<GetAllPaidReport>> GetAllPaidReport()
    {
        var query = await _invoiceDetailRepository.GetAll()
            .Include(id => id.Hirer)
                .ThenInclude(h => h.Apartment)
            .Where(id => id.IsPaid)
            .GroupBy(id => new { ApartmentName = id.Hirer.Apartment.Name, InvoiceType = id.InvoiceType })
            .Select(group => new GetAllPaidReport
            {
                TotalPrice = group.Sum(id => id.Price),
                Apartment = group.Key.ApartmentName,
                InvoiceType = group.Key.InvoiceType
            })
             .OrderBy(result => result.Apartment)
            .ToListAsync();

        return query;
    }




}

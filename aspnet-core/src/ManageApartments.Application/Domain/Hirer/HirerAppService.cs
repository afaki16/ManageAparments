using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using ManageApartments.Authorization;
using ManageApartments.Domain.Hirer.Dtos;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using System;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Hirer;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using ManageApartments.Domain.Apartment.Dtos;
using System.Collections.Generic;
using ManageApartments.Domain.InvoiceDetail.Dtos;
using ManageApartments.Domain.InvoiceDetail;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.InvoiceDetail;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Rent;
using System.Linq.Dynamic.Core;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Fee;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Apartment;
using ManageApartments.Domain.Entities;

namespace ManageApartments.Domain.Hirer;

[AbpAuthorize(PermissionNames.Hirer)]

public class HirerAppService :
    AsyncCrudAppService<Entities.Hirer, HirerFullOutput, int, GetHirerListInput, CreateHirerInput, UpdateHirerInput,
        GetHirerInput, DeleteHirerInput>, IHirerAppService
{
    private readonly IHirerRepository _hirerRepository;
    private readonly IInvoiceDetailRepository _invoiceDetailRepository;
    private readonly IRentRepository _rentRepository;
    private readonly IFeeRepository _feeRepository;
    private readonly IApartmentRepository _apartmentRepository;


    public HirerAppService(IHirerRepository hirerRepository,
        IInvoiceDetailRepository invoiceDetailRepository, 
        IRentRepository rentRepository, 
        IFeeRepository feeRepository,
        IApartmentRepository apartmentRepository) : base(hirerRepository)
    {
        _hirerRepository = hirerRepository;
        _invoiceDetailRepository = invoiceDetailRepository;
        _rentRepository = rentRepository;
        _feeRepository = feeRepository;
        _apartmentRepository = apartmentRepository;

    }

    [HttpPost]
    public async Task<PagedResultDto<HirerFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._hirerRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        query = query.Include(x => x.Apartment);
        query = query.Include(x => x.Apartment)
           .ThenInclude(x => x.Building);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<HirerFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<HirerFullOutput>).ToList()
        );
    }

    [HttpPost]
    public async override Task<HirerFullOutput> CreateAsync(CreateHirerInput input)
    {
        HirerFullOutput createdHirer = new();

        if (input.IsActive == false)
        {
            input.ApartmentId = null;
            input.StartDate = null;
            createdHirer = await base.CreateAsync(input);

        }
        else
        {
            createdHirer = await base.CreateAsync(input);
        

        DateTime? currentDate = createdHirer.StartDate;
        var rent = _rentRepository.GetAll().FirstOrDefault(x=>x.IsActive==true && x.ApartmentId == createdHirer.ApartmentId);
        var fee = _feeRepository.GetAll().FirstOrDefault(x => x.IsActive == true && x.ApartmentId == createdHirer.ApartmentId);



            for (int i = 1; i < 13; i++)
        {
            Entities.InvoiceDetail invoiceDetail = new Entities.InvoiceDetail
            {
                HirerId = createdHirer.Id,
                InvoiceType = Enums.InvoiceType.Rent,
                Description = $"{i}.Ay",
                Price= Convert.ToInt32(rent.Price),
                IsPaid = false,
                InvoiceDate= currentDate
            };

            currentDate = currentDate?.AddMonths(1);

            await _invoiceDetailRepository.InsertAsync(invoiceDetail);

        }
            currentDate = createdHirer.StartDate;
            for (int i = 1; i < 13; i++)
            {
                Entities.InvoiceDetail invoiceDetail = new Entities.InvoiceDetail
                {
                    HirerId = createdHirer.Id,
                    InvoiceType = Enums.InvoiceType.Fee,
                    Description = $"{i}.Ay",
                    Price = Convert.ToInt32(fee.Price),
                    IsPaid = false,
                    InvoiceDate = currentDate
                };

                currentDate = currentDate?.AddMonths(1);

                await _invoiceDetailRepository.InsertAsync(invoiceDetail);

            }
            
            var apartment = _apartmentRepository.GetAll().FirstOrDefault(x => x.Id == createdHirer.ApartmentId);
            apartment.IsActive= true;
            await _apartmentRepository.UpdateAsync(apartment);

        }

        return createdHirer;


    }


    [HttpPut]
    public async override Task<HirerFullOutput> UpdateAsync(UpdateHirerInput input)
    {

        return await base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteHirerInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }

    [HttpGet]
    public async Task<List<HirerPartOutput>> GetHirerPartOutputs()
    {
        var query = this._hirerRepository.GetAll().Include(x => x.Apartment).ToListAsync();
        return this.ObjectMapper.Map<List<HirerPartOutput>>(await query);
    }

    [HttpGet]
    public async Task<List<HirerPartOutput>> GetActiveHirerPartOutputs()
    {
        var query = this._hirerRepository.GetAll().Include(x => x.Apartment).Where(x => x.IsActive != true).ToListAsync();
        return this.ObjectMapper.Map<List<HirerPartOutput>>(await query);

    }



}

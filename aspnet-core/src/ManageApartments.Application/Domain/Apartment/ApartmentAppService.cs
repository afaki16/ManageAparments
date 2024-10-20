using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using ManageApartments.Authorization;
using ManageApartments.Domain.Apartment.Dtos;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using System;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Apartment;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using ManageApartments.Domain.Building.Dtos;
using System.Collections.Generic;
using ManageApartments.Domain.Hirer.Dtos;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Hirer;

namespace ManageApartments.Domain.Apartment;

[AbpAuthorize(PermissionNames.Apartment)]

public class ApartmentAppService :
    AsyncCrudAppService<Entities.Apartment, ApartmentFullOutput, int, GetApartmentListInput, CreateApartmentInput, UpdateApartmentInput,
        GetApartmentInput, DeleteApartmentInput>, IApartmentAppService
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IHirerRepository _hirerRepository;


    public ApartmentAppService(IApartmentRepository apartmentRepository, IHirerRepository hirerRepository) : base(apartmentRepository)
    {
        _apartmentRepository = apartmentRepository;
        _hirerRepository = hirerRepository;

    }

    [HttpPost]
    public async Task<PagedResultDto<ApartmentFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._apartmentRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        query = query.Include(x => x.Building);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<ApartmentFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<ApartmentFullOutput>).ToList()
        );
    }


    [HttpPost]
    public override async Task<ApartmentFullOutput> CreateAsync(CreateApartmentInput input)
    {


            input.IsActive = false;
            return await base.CreateAsync(input);

       
    }


    [HttpPut]
    public override Task<ApartmentFullOutput> UpdateAsync(UpdateApartmentInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteApartmentInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }

    [HttpGet]
    public async Task<List<ApartmentPartOutput>> GetApartmentPartOutputs()
    {
        var query = this._apartmentRepository.GetAll().Include(x => x.Building).Where(x => x.IsActive == true).ToListAsync();
        return this.ObjectMapper.Map<List<ApartmentPartOutput>>(await query);
    }

    [HttpGet]
    public async Task<List<ApartmentPartOutput>> GetActiveApartmentPartOutputs()
    {
        var query = this._apartmentRepository.GetAll().Include(x => x.Building).Where(x=>x.IsActive!=true).ToListAsync();
        return this.ObjectMapper.Map<List<ApartmentPartOutput>>(await query);
    }


}

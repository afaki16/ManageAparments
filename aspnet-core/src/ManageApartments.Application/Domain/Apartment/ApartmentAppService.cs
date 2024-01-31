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

namespace ManageApartments.Domain.Apartment;

[AbpAuthorize(PermissionNames.Apartment)]

public class ApartmentAppService :
    AsyncCrudAppService<Entities.Apartment, ApartmentFullOutput, int, GetApartmentListInput, CreateApartmentInput, UpdateApartmentInput,
        GetApartmentInput, DeleteApartmentInput>, IApartmentAppService
{
    private readonly IApartmentRepository _apartmentRepository;


    public ApartmentAppService(IApartmentRepository apartmentRepository) : base(apartmentRepository)
    {
        _apartmentRepository = apartmentRepository;

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

        var apartments = this._apartmentRepository.GetAllList(x => x.BuildingId == input.BuildingId && x.Name == input.Name).ToList();

        if (apartments.Count == 0)
        {
            var returnVal = await base.CreateAsync(input);

            return returnVal;
        }
        else
        {
            throw new UserFriendlyException(L("Warning"), L("SameNameAndBuildingRecord"));
        }
    }

    //Entities.MaterialTransaction materialTransaction = new Entities.MaterialTransaction()
    //{
    //    ShelfId = oldLocation,
    //    NewShelfId = input.ShelfId,
    //    MaterialId = material.Id,
    //    Description = input.Description,
    //    PhotoUrl = input.PhotoUrl,
    //    UserId = input.UserId,
    //};

    //await _materialTransactionRepository.InsertAsync(materialTransaction);

    //        return ObjectMapper.Map<MaterialFullOutput>(material);


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
        var query = this._apartmentRepository.GetAll().Include(x => x.Building).ToListAsync();
        return this.ObjectMapper.Map<List<ApartmentPartOutput>>(await query);
    }


}

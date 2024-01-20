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
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<ApartmentFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<ApartmentFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<ApartmentFullOutput> CreateAsync(CreateApartmentInput input)
    {

        return base.CreateAsync(input);
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


}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ManageApartments.Authorization;
using ManageApartments.Domain.Building.Dtos;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Building;

namespace ManageApartments.Domain.Building;

[AbpAuthorize(PermissionNames.Building)]

public class BuildingAppService :
    AsyncCrudAppService<Entities.Building, BuildingFullOutput, int, GetBuildingListInput, CreateBuildingInput, UpdateBuildingInput,
        GetBuildingInput, DeleteBuildingInput>, IBuildingAppService
{
    private readonly IBuildingRepository _buildingRepository;


    public BuildingAppService(IBuildingRepository buildingRepository) : base(buildingRepository)
    {
        _buildingRepository = buildingRepository;

    }

    [HttpPost]
    public async Task<PagedResultDto<BuildingFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._buildingRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<BuildingFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<BuildingFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<BuildingFullOutput> CreateAsync(CreateBuildingInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<BuildingFullOutput> UpdateAsync(UpdateBuildingInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteBuildingInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }


}

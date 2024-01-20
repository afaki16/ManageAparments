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

namespace ManageApartments.Domain.Hirer;

[AbpAuthorize(PermissionNames.Hirer)]

public class HirerAppService :
    AsyncCrudAppService<Entities.Hirer, HirerFullOutput, int, GetHirerListInput, CreateHirerInput, UpdateHirerInput,
        GetHirerInput, DeleteHirerInput>, IHirerAppService
{
    private readonly IHirerRepository _hirerRepository;


    public HirerAppService(IHirerRepository hirerRepository) : base(hirerRepository)
    {
        _hirerRepository = hirerRepository;

    }

    [HttpPost]
    public async Task<PagedResultDto<HirerFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._hirerRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<HirerFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<HirerFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<HirerFullOutput> CreateAsync(CreateHirerInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<HirerFullOutput> UpdateAsync(UpdateHirerInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteHirerInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }


}

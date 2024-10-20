using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using ManageApartments.Authorization;
using ManageApartments.Domain.Electric.Dtos;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Electric;



namespace ManageApartments.Domain.Electric;

[AbpAuthorize(PermissionNames.Electric)]

public class ElectricAppService :
 AsyncCrudAppService<Entities.Electric, ElectricFullOutput, int, GetElectricListInput, CreateElectricInput, UpdateElectricInput,
     GetElectricInput, DeleteElectricInput>, IElectricAppService
{
    private readonly IElectricRepository _electricRepository;

    public ElectricAppService(IElectricRepository electricRepository) : base(electricRepository)
    {
        _electricRepository = electricRepository;

    }
    [HttpPost]
    public async Task<PagedResultDto<ElectricFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._electricRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);


        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<ElectricFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<ElectricFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<ElectricFullOutput> CreateAsync(CreateElectricInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<ElectricFullOutput> UpdateAsync(UpdateElectricInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteElectricInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }
}


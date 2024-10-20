using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using ManageApartments.Authorization;
using ManageApartments.Domain.Fee.Dtos;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Fee;



namespace ManageApartments.Domain.Fee;

[AbpAuthorize(PermissionNames.Fee)]

public class FeeAppService :
 AsyncCrudAppService<Entities.Fee, FeeFullOutput, int, GetFeeListInput, CreateFeeInput, UpdateFeeInput,
     GetFeeInput, DeleteFeeInput>, IFeeAppService
{
    private readonly IFeeRepository _feeRepository;

    public FeeAppService(IFeeRepository feeRepository) : base(feeRepository)
    {
        _feeRepository = feeRepository;

    }
    [HttpPost]
    public async Task<PagedResultDto<FeeFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._feeRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);


        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<FeeFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<FeeFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<FeeFullOutput> CreateAsync(CreateFeeInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<FeeFullOutput> UpdateAsync(UpdateFeeInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteFeeInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }
}


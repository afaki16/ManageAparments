using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using ManageApartments.Authorization;
using ManageApartments.Domain.Rent.Dtos;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Rent;



namespace ManageApartments.Domain.Rent;

[AbpAuthorize(PermissionNames.Rent)]

public class RentAppService :
 AsyncCrudAppService<Entities.Rent, RentFullOutput, int, GetRentListInput, CreateRentInput, UpdateRentInput,
     GetRentInput, DeleteRentInput>, IRentAppService
{
    private readonly IRentRepository _rentRepository;

    public RentAppService(IRentRepository rentRepository) : base(rentRepository)
    {
        _rentRepository = rentRepository;

    }
    [HttpPost]
    public async Task<PagedResultDto<RentFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._rentRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);


        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<RentFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<RentFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<RentFullOutput> CreateAsync(CreateRentInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<RentFullOutput> UpdateAsync(UpdateRentInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteRentInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }
}


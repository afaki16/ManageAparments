using Abp.Application.Services;
using Abp.Authorization;
using ManageApartments.Authorization;
using ManageApartments.Domain.ExpenseType.Dtos;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.ExpenseType;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using PrimeNG.TableFilter.Models;
using PrimeNG.TableFilter;
using ManageApartments.Domain.Apartment.Dtos;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ManageApartments.Domain.ExpenseType;

[AbpAuthorize(PermissionNames.ExpenseType)]

  public class ExpenseTypeAppService :
    AsyncCrudAppService<Entities.ExpenseType, ExpenseTypeFullOutput, int, GetExpenseTypeListInput, CreateExpenseTypeInput, UpdateExpenseTypeInput,
        GetExpenseTypeInput, DeleteExpenseTypeInput>, IExpenseTypeAppService
{
    private readonly IExpenseTypeRepository _expenseTypeRepository;

    public ExpenseTypeAppService(IExpenseTypeRepository expenseTypeRepository) : base(expenseTypeRepository)
    {
        _expenseTypeRepository = expenseTypeRepository;

    }

    [HttpPost]
    public async Task<PagedResultDto<ExpenseTypeFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._expenseTypeRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<ExpenseTypeFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<ExpenseTypeFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<ExpenseTypeFullOutput> CreateAsync(CreateExpenseTypeInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<ExpenseTypeFullOutput> UpdateAsync(UpdateExpenseTypeInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteExpenseTypeInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }

    [HttpGet]
    public async Task<List<ExpenseTypePartOutput>> GetExpenseTypePartOutputs()
    {
        var query = this._expenseTypeRepository.GetAll().ToListAsync();
        return this.ObjectMapper.Map<List<ExpenseTypePartOutput>>(await query);
    }

}


using Abp.Application.Services;
using Abp.Authorization;
using ManageApartments.Authorization;
using ManageApartments.Domain.Expense.Dtos;
using ManageApartments.Domain.Expense;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.Expense;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using PrimeNG.TableFilter.Models;

namespace ManageApartments.Domain.Expense;

[AbpAuthorize(PermissionNames.Expense)]

public class ExpenseAppService :
 AsyncCrudAppService<Entities.Expense, ExpenseFullOutput, int, GetExpenseListInput, CreateExpenseInput, UpdateExpenseInput,
     GetExpenseInput, DeleteExpenseInput>, IExpenseAppService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseAppService(IExpenseRepository expenseRepository) : base(expenseRepository)
    {
        _expenseRepository = expenseRepository;

    }
    [HttpPost]
    public async Task<PagedResultDto<ExpenseFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._expenseRepository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        query = query.Include(x => x.Hirer);
        query = query.Include(x => x.Invoice);

        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<ExpenseFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<ExpenseFullOutput>).ToList()
        );
    }

    [HttpPost]
    public override Task<ExpenseFullOutput> CreateAsync(CreateExpenseInput input)
    {

        return base.CreateAsync(input);
    }


    [HttpPut]
    public override Task<ExpenseFullOutput> UpdateAsync(UpdateExpenseInput input)
    {

        return base.UpdateAsync(input);
    }


    [HttpDelete]
    public override Task DeleteAsync(DeleteExpenseInput input)
    {

        return Repository.DeleteAsync(input.Id);

    }
}


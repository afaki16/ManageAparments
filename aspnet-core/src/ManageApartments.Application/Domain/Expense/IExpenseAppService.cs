using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ManageApartments.Domain.Expense.Dtos;
using PrimeNG.TableFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Expense
{
    public interface IExpenseAppService : IAsyncCrudAppService<ExpenseFullOutput, int, GetExpenseListInput, CreateExpenseInput,
   UpdateExpenseInput, GetExpenseInput, DeleteExpenseInput>
    {
        Task<PagedResultDto<ExpenseFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);

    }
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ManageApartments.Domain.ExpenseType.Dtos;
using PrimeNG.TableFilter.Models;
using System.Threading.Tasks;

namespace ManageApartments.Domain.ExpenseType
{
    public interface IExpenseTypeAppService : IAsyncCrudAppService<ExpenseTypeFullOutput, int, GetExpenseTypeListInput, CreateExpenseTypeInput,
    UpdateExpenseTypeInput, GetExpenseTypeInput, DeleteExpenseTypeInput>
    {
        Task<PagedResultDto<ExpenseTypeFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);



    }
}

using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System.Threading.Tasks;
using PrimeNG.TableFilter.Models;
using ManageApartments.Domain.Hirer.Dtos;

namespace ManageApartments.Domain.Hirer
{

    public interface IHirerAppService : IAsyncCrudAppService<HirerFullOutput, int, GetHirerListInput, CreateHirerInput,
    UpdateHirerInput, GetHirerInput, DeleteHirerInput>
    {
        Task<PagedResultDto<HirerFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);
   
    }
}

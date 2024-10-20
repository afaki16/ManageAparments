using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeNG.TableFilter.Models;
using ManageApartments.Domain.Building.Dtos;

namespace ManageApartments.Domain.Building
{

    public interface IBuildingAppService : IAsyncCrudAppService<BuildingFullOutput, int, GetBuildingListInput, CreateBuildingInput,
    UpdateBuildingInput, GetBuildingInput, DeleteBuildingInput>
    {
        Task<PagedResultDto<BuildingFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);
   
    }
}

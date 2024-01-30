using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ManageApartments.Domain.Electric.Dtos;
using PrimeNG.TableFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Electric
{
    public interface IElectricAppService : IAsyncCrudAppService<ElectricFullOutput, int, GetElectricListInput, CreateElectricInput,
   UpdateElectricInput, GetElectricInput, DeleteElectricInput>
    {
        Task<PagedResultDto<ElectricFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);

    }
}

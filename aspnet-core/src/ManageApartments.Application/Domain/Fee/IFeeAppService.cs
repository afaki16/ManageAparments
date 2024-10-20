using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ManageApartments.Domain.Fee.Dtos;
using PrimeNG.TableFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Fee
{
    public interface IFeeAppService : IAsyncCrudAppService<FeeFullOutput, int, GetFeeListInput, CreateFeeInput,
   UpdateFeeInput, GetFeeInput, DeleteFeeInput>
    {
        Task<PagedResultDto<FeeFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);

    }
}

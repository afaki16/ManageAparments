using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ManageApartments.Domain.Rent.Dtos;
using PrimeNG.TableFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageApartments.Domain.Rent
{
    public interface IRentAppService : IAsyncCrudAppService<RentFullOutput, int, GetRentListInput, CreateRentInput,
   UpdateRentInput, GetRentInput, DeleteRentInput>
    {
        Task<PagedResultDto<RentFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);

    }
}

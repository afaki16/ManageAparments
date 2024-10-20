using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System.Threading.Tasks;
using PrimeNG.TableFilter.Models;
using ManageApartments.Domain.Apartment.Dtos;

namespace ManageApartments.Domain.Apartment
{

    public interface IApartmentAppService : IAsyncCrudAppService<ApartmentFullOutput, int, GetApartmentListInput, CreateApartmentInput,
    UpdateApartmentInput, GetApartmentInput, DeleteApartmentInput>
    {
        Task<PagedResultDto<ApartmentFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);
   
    }
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PrimeNG.TableFilter.Models;
using ManageApartments.Domain.LoginImage.Dtos;
using System.Threading.Tasks;

namespace Swiss.InventoryManagement.Domain.LoginImage;

public interface ILoginImageAppService : IAsyncCrudAppService<LoginImageFullOutput, int, GetLoginImageListInput, CreateLoginImageInput,
    UpdateLoginImageInput, GetLoginImageInput, DeleteLoginImageInput>
{
    Task<PagedResultDto<LoginImageFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload);
}

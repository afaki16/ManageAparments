using Abp.Application.Services;
using ManageApartments.MultiTenancy.Dto;

namespace ManageApartments.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


using System.Threading.Tasks;
using Abp.Application.Services;
using ManageApartments.Sessions.Dto;

namespace ManageApartments.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

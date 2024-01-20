using System.Threading.Tasks;
using ManageApartments.Configuration.Dto;

namespace ManageApartments.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

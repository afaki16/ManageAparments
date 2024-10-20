using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ManageApartments.Configuration.Dto;

namespace ManageApartments.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ManageApartmentsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

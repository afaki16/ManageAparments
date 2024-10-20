using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ManageApartments.Controllers
{
    public abstract class ManageApartmentsControllerBase: AbpController
    {
        protected ManageApartmentsControllerBase()
        {
            LocalizationSourceName = ManageApartmentsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ManageApartments.Configuration;

namespace ManageApartments.Web.Host.Startup
{
    [DependsOn(
       typeof(ManageApartmentsWebCoreModule))]
    public class ManageApartmentsWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ManageApartmentsWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ManageApartmentsWebHostModule).GetAssembly());
        }
    }
}

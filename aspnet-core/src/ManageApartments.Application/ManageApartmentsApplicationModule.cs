using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ManageApartments.Authorization;
using ManageApartments.Manager;

namespace ManageApartments
{
    [DependsOn(
        typeof(ManageApartmentsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ManageApartmentsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ManageApartmentsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ManageApartmentsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                cfg.AddMaps(thisAssembly);
                MapperManager.DomainToDtos(cfg);
                MapperManager.DtosToDomain(cfg);
            });
        }
    }
}

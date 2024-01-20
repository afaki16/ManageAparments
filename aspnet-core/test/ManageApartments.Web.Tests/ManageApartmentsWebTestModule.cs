using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ManageApartments.EntityFrameworkCore;
using ManageApartments.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ManageApartments.Web.Tests
{
    [DependsOn(
        typeof(ManageApartmentsWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ManageApartmentsWebTestModule : AbpModule
    {
        public ManageApartmentsWebTestModule(ManageApartmentsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ManageApartmentsWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ManageApartmentsWebMvcModule).Assembly);
        }
    }
}
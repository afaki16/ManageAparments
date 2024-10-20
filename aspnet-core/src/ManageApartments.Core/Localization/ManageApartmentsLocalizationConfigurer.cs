using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ManageApartments.Localization
{
    public static class ManageApartmentsLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ManageApartmentsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ManageApartmentsLocalizationConfigurer).GetAssembly(),
                        "ManageApartments.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

using ManageApartments.Debugging;

namespace ManageApartments
{
    public class ManageApartmentsConsts
    {
        public const string LocalizationSourceName = "ManageApartments";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ef79bed3de98442694b894d7329ccef8";
    }
}

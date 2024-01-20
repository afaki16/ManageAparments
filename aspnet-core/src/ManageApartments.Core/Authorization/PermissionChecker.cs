using Abp.Authorization;
using ManageApartments.Authorization.Roles;
using ManageApartments.Authorization.Users;

namespace ManageApartments.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ManageApartments.Authorization
{
    public class ManageApartmentsAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            //Building
            var buildingParentPermission =
             context.CreatePermission(PermissionNames.Building, L(PermissionNames.Building));

            var buildingCreatePermission =
                buildingParentPermission.CreateChildPermission(PermissionNames.Building_Create,
                    L(PermissionNames.Building_Create));
            var buildingGetPermission =
                buildingParentPermission.CreateChildPermission(PermissionNames.Building_Get,
                    L(PermissionNames.Building_Get));
            var buildingGetListPermission =
                buildingParentPermission.CreateChildPermission(PermissionNames.Building_GetList,
                    L(PermissionNames.Building_GetList));
            var buildingUpdatePermission =
                buildingParentPermission.CreateChildPermission(PermissionNames.Building_Update,
                    L(PermissionNames.Building_Update));
            var buildingDeletePermission =
                buildingParentPermission.CreateChildPermission(PermissionNames.Building_Delete,
                    L(PermissionNames.Building_Delete));

            //Apartment
            var apartmentParentPermission =
             context.CreatePermission(PermissionNames.Apartment, L(PermissionNames.Apartment));

            var apartmentCreatePermission =
                apartmentParentPermission.CreateChildPermission(PermissionNames.Apartment_Create,
                    L(PermissionNames.Apartment_Create));
            var apartmentGetPermission =
                apartmentParentPermission.CreateChildPermission(PermissionNames.Apartment_Get,
                    L(PermissionNames.Apartment_Get));
            var apartmentGetListPermission =
                apartmentParentPermission.CreateChildPermission(PermissionNames.Apartment_GetList,
                    L(PermissionNames.Apartment_GetList));
            var apartmentUpdatePermission =
                apartmentParentPermission.CreateChildPermission(PermissionNames.Apartment_Update,
                    L(PermissionNames.Apartment_Update));
            var apartmentDeletePermission =
                apartmentParentPermission.CreateChildPermission(PermissionNames.Apartment_Delete,
                    L(PermissionNames.Apartment_Delete));

            //Hirer
            var hirerParentPermission =
             context.CreatePermission(PermissionNames.Hirer, L(PermissionNames.Hirer));

            var hirerCreatePermission =
                hirerParentPermission.CreateChildPermission(PermissionNames.Hirer_Create,
                    L(PermissionNames.Hirer_Create));
            var hirerGetPermission =
                hirerParentPermission.CreateChildPermission(PermissionNames.Hirer_Get,
                    L(PermissionNames.Hirer_Get));
            var hirerGetListPermission =
                hirerParentPermission.CreateChildPermission(PermissionNames.Hirer_GetList,
                    L(PermissionNames.Hirer_GetList));
            var hirerUpdatePermission =
                hirerParentPermission.CreateChildPermission(PermissionNames.Hirer_Update,
                    L(PermissionNames.Hirer_Update));
            var hirerDeletePermission =
                hirerParentPermission.CreateChildPermission(PermissionNames.Hirer_Delete,
                    L(PermissionNames.Hirer_Delete));

            //Invoice
            var invoiceParentPermission =
             context.CreatePermission(PermissionNames.Invoice, L(PermissionNames.Invoice));

            var invoiceCreatePermission =
                invoiceParentPermission.CreateChildPermission(PermissionNames.Invoice_Create,
                    L(PermissionNames.Invoice_Create));
            var invoiceGetPermission =
                invoiceParentPermission.CreateChildPermission(PermissionNames.Invoice_Get,
                    L(PermissionNames.Invoice_Get));
            var invoiceGetListPermission =
                invoiceParentPermission.CreateChildPermission(PermissionNames.Invoice_GetList,
                    L(PermissionNames.Invoice_GetList));
            var invoiceUpdatePermission =
                invoiceParentPermission.CreateChildPermission(PermissionNames.Invoice_Update,
                    L(PermissionNames.Invoice_Update));
            var invoiceDeletePermission =
                invoiceParentPermission.CreateChildPermission(PermissionNames.Invoice_Delete,
                    L(PermissionNames.Invoice_Delete));

            //InvoiceDetail
            var invoiceDetailParentPermission =
             context.CreatePermission(PermissionNames.InvoiceDetail, L(PermissionNames.InvoiceDetail));

            var invoiceDetailCreatePermission =
                invoiceDetailParentPermission.CreateChildPermission(PermissionNames.InvoiceDetail_Create,
                    L(PermissionNames.InvoiceDetail_Create));
            var invoiceDetailGetPermission =
                invoiceDetailParentPermission.CreateChildPermission(PermissionNames.InvoiceDetail_Get,
                    L(PermissionNames.InvoiceDetail_Get));
            var invoiceDetailGetListPermission =
                invoiceDetailParentPermission.CreateChildPermission(PermissionNames.InvoiceDetail_GetList,
                    L(PermissionNames.InvoiceDetail_GetList));
            var invoiceDetailUpdatePermission =
                invoiceDetailParentPermission.CreateChildPermission(PermissionNames.InvoiceDetail_Update,
                    L(PermissionNames.InvoiceDetail_Update));
            var invoiceDetailDeletePermission =
                invoiceDetailParentPermission.CreateChildPermission(PermissionNames.InvoiceDetail_Delete,
                    L(PermissionNames.InvoiceDetail_Delete));
      

            //Expense
            var expenseParentPermission =
             context.CreatePermission(PermissionNames.Expense, L(PermissionNames.Expense));

            var expenseCreatePermission =
                expenseParentPermission.CreateChildPermission(PermissionNames.Expense_Create,
                    L(PermissionNames.Expense_Create));
            var expenseGetPermission =
                expenseParentPermission.CreateChildPermission(PermissionNames.Expense_Get,
                    L(PermissionNames.Expense_Get));
            var expenseGetListPermission =
                expenseParentPermission.CreateChildPermission(PermissionNames.Expense_GetList,
                    L(PermissionNames.Expense_GetList));
            var expenseUpdatePermission =
                expenseParentPermission.CreateChildPermission(PermissionNames.Expense_Update,
                    L(PermissionNames.Expense_Update));
            var expenseDeletePermission =
                expenseParentPermission.CreateChildPermission(PermissionNames.Expense_Delete,
                    L(PermissionNames.Expense_Delete));

            //ExpenseType
            var expenseTypeParentPermission =
             context.CreatePermission(PermissionNames.ExpenseType, L(PermissionNames.ExpenseType));

            var expenseTypeCreatePermission =
                expenseTypeParentPermission.CreateChildPermission(PermissionNames.ExpenseType_Create,
                    L(PermissionNames.ExpenseType_Create));
            var expenseTypeGetPermission =
                expenseTypeParentPermission.CreateChildPermission(PermissionNames.ExpenseType_Get,
                    L(PermissionNames.ExpenseType_Get));
            var expenseTypeGetListPermission =
                expenseTypeParentPermission.CreateChildPermission(PermissionNames.ExpenseType_GetList,
                    L(PermissionNames.ExpenseType_GetList));
            var expenseTypeUpdatePermission =
                expenseTypeParentPermission.CreateChildPermission(PermissionNames.ExpenseType_Update,
                    L(PermissionNames.ExpenseType_Update));
            var expenseTypeDeletePermission =
                expenseTypeParentPermission.CreateChildPermission(PermissionNames.ExpenseType_Delete,
                    L(PermissionNames.ExpenseType_Delete));








        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ManageApartmentsConsts.LocalizationSourceName);
        }
    }
}

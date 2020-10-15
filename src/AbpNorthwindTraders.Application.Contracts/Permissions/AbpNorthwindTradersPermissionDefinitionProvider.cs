using AbpNorthwindTraders.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpNorthwindTraders.Permissions
{
    public class AbpNorthwindTradersPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpNorthwindTradersPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpNorthwindTradersPermissions.MyPermission1, L("Permission:MyPermission1"));

            var employeePermission = myGroup.AddPermission(AbpNorthwindTradersPermissions.Employee.Default, L("Permission:Employee"));
            employeePermission.AddChild(AbpNorthwindTradersPermissions.Employee.Create, L("Permission:Create"));
            employeePermission.AddChild(AbpNorthwindTradersPermissions.Employee.Update, L("Permission:Update"));
            employeePermission.AddChild(AbpNorthwindTradersPermissions.Employee.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpNorthwindTradersResource>(name);
        }
    }
}

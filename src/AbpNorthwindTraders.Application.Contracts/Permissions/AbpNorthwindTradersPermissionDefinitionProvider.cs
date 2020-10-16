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

            var regionPermission = myGroup.AddPermission(AbpNorthwindTradersPermissions.Region.Default, L("Permission:Region"));
            regionPermission.AddChild(AbpNorthwindTradersPermissions.Region.Create, L("Permission:Create"));
            regionPermission.AddChild(AbpNorthwindTradersPermissions.Region.Update, L("Permission:Update"));
            regionPermission.AddChild(AbpNorthwindTradersPermissions.Region.Delete, L("Permission:Delete"));

            var territoryPermission = myGroup.AddPermission(AbpNorthwindTradersPermissions.Territory.Default, L("Permission:Territory"));
            territoryPermission.AddChild(AbpNorthwindTradersPermissions.Territory.Create, L("Permission:Create"));
            territoryPermission.AddChild(AbpNorthwindTradersPermissions.Territory.Update, L("Permission:Update"));
            territoryPermission.AddChild(AbpNorthwindTradersPermissions.Territory.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpNorthwindTradersResource>(name);
        }
    }
}

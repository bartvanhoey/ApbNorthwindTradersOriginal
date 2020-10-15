namespace AbpNorthwindTraders.Permissions
{
    public static class AbpNorthwindTradersPermissions
    {
        public const string GroupName = "AbpNorthwindTraders";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Employee
        {
            public const string Default = GroupName + ".Employee";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}

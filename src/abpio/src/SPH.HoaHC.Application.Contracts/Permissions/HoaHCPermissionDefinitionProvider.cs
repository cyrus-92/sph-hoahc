using SPH.HoaHC.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SPH.HoaHC.Permissions
{
    public class HoaHCPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HoaHCPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(HoaHCPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HoaHCResource>(name);
        }
    }
}

using SPH.HoaHC.DataGov.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SPH.HoaHC.DataGov.Permissions
{
    public class DataGovPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DataGovPermissions.GroupName, L("Permission:DataGov"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DataGovResource>(name);
        }
    }
}
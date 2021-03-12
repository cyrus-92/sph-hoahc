using Volo.Abp.Reflection;

namespace SPH.HoaHC.DataGov.Permissions
{
    public class DataGovPermissions
    {
        public const string GroupName = "DataGov";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DataGovPermissions));
        }
    }
}
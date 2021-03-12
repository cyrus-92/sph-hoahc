using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SPH.HoaHC.DataGov.EntityFrameworkCore
{
    public class DataGovModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public DataGovModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
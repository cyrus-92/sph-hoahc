using SPH.HoaHC.DataGov.Localization;
using Volo.Abp.Application.Services;

namespace SPH.HoaHC.DataGov
{
    public abstract class DataGovAppService : ApplicationService
    {
        protected DataGovAppService()
        {
            LocalizationResource = typeof(DataGovResource);
            ObjectMapperContext = typeof(DataGovApplicationModule);
        }
    }
}

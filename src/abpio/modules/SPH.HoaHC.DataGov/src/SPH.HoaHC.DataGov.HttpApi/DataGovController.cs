using SPH.HoaHC.DataGov.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SPH.HoaHC.DataGov
{
    public abstract class DataGovController : AbpController
    {
        protected DataGovController()
        {
            LocalizationResource = typeof(DataGovResource);
        }
    }
}

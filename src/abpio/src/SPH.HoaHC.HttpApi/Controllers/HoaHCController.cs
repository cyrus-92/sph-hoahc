using SPH.HoaHC.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SPH.HoaHC.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class HoaHCController : AbpController
    {
        protected HoaHCController()
        {
            LocalizationResource = typeof(HoaHCResource);
        }
    }
}
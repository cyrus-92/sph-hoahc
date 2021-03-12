using SPH.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SPH.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class SPHController : AbpController
    {
        protected SPHController()
        {
            LocalizationResource = typeof(SPHResource);
        }
    }
}
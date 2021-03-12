using System;
using System.Collections.Generic;
using System.Text;
using SPH.HoaHC.Localization;
using Volo.Abp.Application.Services;

namespace SPH.HoaHC
{
    /* Inherit your application services from this class.
     */
    public abstract class HoaHCAppService : ApplicationService
    {
        protected HoaHCAppService()
        {
            LocalizationResource = typeof(HoaHCResource);
        }
    }
}

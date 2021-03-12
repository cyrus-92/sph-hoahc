using System;
using System.Collections.Generic;
using System.Text;
using SPH.Localization;
using Volo.Abp.Application.Services;

namespace SPH
{
    /* Inherit your application services from this class.
     */
    public abstract class SPHAppService : ApplicationService
    {
        protected SPHAppService()
        {
            LocalizationResource = typeof(SPHResource);
        }
    }
}

using SPH.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SPH.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class SPHPageModel : AbpPageModel
    {
        protected SPHPageModel()
        {
            LocalizationResourceType = typeof(SPHResource);
        }
    }
}
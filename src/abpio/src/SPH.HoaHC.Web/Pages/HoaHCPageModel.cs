using SPH.HoaHC.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SPH.HoaHC.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class HoaHCPageModel : AbpPageModel
    {
        protected HoaHCPageModel()
        {
            LocalizationResourceType = typeof(HoaHCResource);
        }
    }
}
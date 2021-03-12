using SPH.HoaHC.DataGov.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SPH.HoaHC.DataGov.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DataGovPageModel : AbpPageModel
    {
        protected DataGovPageModel()
        {
            LocalizationResourceType = typeof(DataGovResource);
            ObjectMapperContext = typeof(DataGovWebModule);
        }
    }
}
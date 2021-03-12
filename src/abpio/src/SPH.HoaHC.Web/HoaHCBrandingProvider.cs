using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SPH.HoaHC.Web
{
    [Dependency(ReplaceServices = true)]
    public class HoaHCBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "HoaHC";
    }
}

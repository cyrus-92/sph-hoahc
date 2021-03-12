using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SPH.Web
{
    [Dependency(ReplaceServices = true)]
    public class SPHBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "SPH";
    }
}

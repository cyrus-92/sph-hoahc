using Volo.Abp.Settings;

namespace SPH.HoaHC.Settings
{
    public class HoaHCSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(HoaHCSettings.MySetting1));
        }
    }
}

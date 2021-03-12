using Volo.Abp.Settings;

namespace SPH.Settings
{
    public class SPHSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(SPHSettings.MySetting1));
        }
    }
}

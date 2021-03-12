using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace SPH.HoaHC.DataGov.Web.Menus
{
    public class DataGovMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(DataGovMenus.Prefix, displayName: "DataGov", "~/DataGov", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}
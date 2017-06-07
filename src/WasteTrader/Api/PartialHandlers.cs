using Starcounter;
using WasteTrader.Database;
using WasteTrader.ViewModels;

namespace WasteTrader.Api
{
    public class PartialHandlers : IHandler
    {
        public void Register()
        {
            Handle.GET("/Waste2Value/partial/Hitta", () =>
            {
                var page = new FindPage();
                page.Waste.Data = Db.SQL<Waste>($"SELECT w FROM {typeof(Waste)} w ORDER BY w.{nameof(Waste.EntryTime)} DESC");
                return page;
            });

            Handle.GET("/Waste2Value/partial/Home", () => new HomePage());

            Handle.GET("/Waste2Value/partial/drawer", () => new Drawer());

            Handle.GET("/Waste2Value/partial/header", () => new Header());
        }
    }
}

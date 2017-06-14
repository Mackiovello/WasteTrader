using Starcounter;
using WasteTrader.Database;
using WasteTrader.ViewModels;
using WasteTrader.ViewModels.Sorters;

namespace WasteTrader.Api
{
    public class PartialHandlers : IHandler
    {

        protected HandlerOptions internalOption = new HandlerOptions { SelfOnly = true };

        public void Register()
        {
            Handle.GET("/Waste2Value/partial/Hitta", () =>
            {
                var page = new FindPage();
                page.Filter = new MatchParametersPage
                {
                    Sorter = new DateSorterPage(),
                    SelectedSorter = "DateSorter",
                    WasteDump = (Waste[] w) => { page.Waste.Data = w; }
                };
                page.Waste.Data = Db.SQL<Waste>($"SELECT w FROM {typeof(Waste)} w ORDER BY w.{nameof(Waste.EntryTime)} DESC");
                return page;
            }, internalOption);

            Handle.GET("/Waste2Value/partial/Home", () => new HomePage(), internalOption);

            Handle.GET("/Waste2Value/partial/drawer", () => new Drawer(), internalOption);

            Handle.GET("/Waste2Value/partial/header", () => new Header(), internalOption);

            Handle.GET("/Waste2Value/partial/logon", () => new LogonPage(), internalOption);
        }
    }
}

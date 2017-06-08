using Starcounter;
using WasteTrader.Database;
using WasteTrader.ViewModels;
using WasteTrader.ViewModels.Sorters;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.Api
{
    public class PartialHandlers : IHandler
    {
        public void Register()
        {
            Handle.GET("/Waste2Value/partial/Hitta", () =>
            {
                var page = new FindPage();
                page.Filter = new MatchParametersPage
                {
                    Sorter = new DateSorterPage(),
                    SelectedSorter = "DateSorter",
                    WasteDump = (Waste[] w) => { page.Waste.Data = w; },
                    SorterType = typeof(DateSorter),
                };
                page.Waste.Data = Db.SQL<Waste>($"SELECT w FROM {typeof(Waste)} w ORDER BY w.{nameof(Waste.EntryTime)} DESC");
                return page;
            });

            Handle.GET("/Waste2Value/partial/Home", () => new HomePage());

            Handle.GET("/Waste2Value/partial/drawer", () => new Drawer());

            Handle.GET("/Waste2Value/partial/header", () => new Header());
        }
    }
}

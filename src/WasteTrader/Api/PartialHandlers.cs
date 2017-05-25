using Starcounter;
using WasteTrader.Database;
using WasteTrader.ViewModels;

namespace WasteTrader.Api
{
    public class PartialHandlers
    {
        public void Register()
        {
            Handle.GET("/WasteTrader/partial/Find", () =>
            {
                var page = new FindPage();
                page.Waste.Data = Db.SQL<Waste>("SELECT w FROM WasteTrader.Database.Waste w");
                return page;
            });
        }
    }
}

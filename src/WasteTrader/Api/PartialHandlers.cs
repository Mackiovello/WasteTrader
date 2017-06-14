using Starcounter;
using WasteTrader.Database;
using WasteTrader.ViewModels;
using WasteTrader.ViewModels.Sorters;
using Simplified.Ring3;
using System.Linq;

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
                    WasteDump = (Waste[] w) => { page.SellWaste.Data = w; }
                };
                page.SellWaste.Data = Db.SQL<Waste>($"SELECT w FROM {typeof(Waste)} w ORDER BY w.{nameof(Waste.EntryTime)} DESC");
                return page;
            }, internalOption);

            Handle.GET("/Waste2Value/partial/Home", () => new HomePage(), internalOption);

            Handle.GET("/Waste2Value/partial/drawer", () => new Drawer(), internalOption);

            Handle.GET("/Waste2Value/partial/header", () => new Header(), internalOption);

            Handle.GET("/Waste2Value/partial/logon", () => new LogonPage(), internalOption);

            Handle.GET("/Waste2Value/partial/user/{?}", (string username) => {
                var page = new UserPage();
                SystemUser user = Db.SQL<SystemUser>($"SELECT u FROM {typeof(SystemUser)} u WHERE u.{nameof(SystemUser.Name)} = ?", username).FirstOrDefault();
                page.Data = user;
                page.SellWastes.Data = Db.SQL<SellWaste>($"SELECT w FROM {typeof(SellWaste)} w WHERE w.{nameof(SellWaste.User)} = ?", user);
                page.BuyWastes.Data = Db.SQL<BuyWaste>($"SELECT w FROM {typeof(BuyWaste)} w WHERE w.{nameof(BuyWaste.User)} = ?", user);
                return page;
            }, internalOption);
        }
    }
}

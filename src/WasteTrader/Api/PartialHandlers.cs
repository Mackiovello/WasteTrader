using Simplified.Ring3;
using Starcounter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;
using WasteTrader.Helpers;
using WasteTrader.ViewModels;
using WasteTrader.ViewModels.Sorters;

namespace WasteTrader.Api
{
    public class PartialHandlers : IHandler
    {
        private static readonly string SELECT_WASTE_BY_ENTRYTIME =
            $"SELECT w FROM {typeof(Waste)} w ORDER BY w.{nameof(Waste.EntryTime)} DESC";
        private static readonly string SELECT_WASTE = $"SELECT w FROM {typeof(Waste)} w";
        private static readonly string SELECT_SELLWASTE = $"SELECT w FROM {typeof(SellWaste)} w";
        private static readonly string SELECT_BUYWASTE = $"SELECT w FROM {typeof(BuyWaste)} w";

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
                    WasteDump = (Waste[] waste) => page.WasteEntries.Data = waste
                };
                page.WasteEntries.Data = Db.SQL<Waste>(SELECT_WASTE_BY_ENTRYTIME).Where(w => w.Active);
                return page;
            }, internalOption);

            Handle.GET("/Waste2Value/partial/drawer", () => new Drawer(), internalOption);

            Handle.GET("/Waste2Value/partial/Home", () => new HomePage(), internalOption);

            Handle.GET("/Waste2Value/partial/header", () => new Header(), internalOption);

            Handle.GET("/Waste2Value/partial/logon", () =>  new Json(), internalOption);

            Handle.GET("/Waste2Value/partial/user/{?}", (string username) => 
            {
                return new UserPage()
                {
                    Data = Client.GetClientFromUsername(username)
                };
            }, internalOption);

            Handle.GET("/Waste2Value/partial/waste/{?}", (string objectId) =>
            {
                Waste waste = Db.FromId<Waste>(objectId);

                return new WastePage() { Data = waste};
            }, internalOption);

            Handle.GET("/Waste2Value/partial/matchning/{?}", (string objectId) =>
            {
                Waste wasteToMatch = Db.FromId<Waste>(objectId);

                string query = wasteToMatch.GetType() == typeof(SellWaste) ?
                    SELECT_BUYWASTE :
                    SELECT_SELLWASTE;

                IEnumerable<Waste> toMatchAgainst = Db.SQL<Waste>(query)
                    .Where(w => w.Key != wasteToMatch.Key);

                IEnumerable<Waste> matches = new WasteMatching(wasteToMatch, toMatchAgainst).Match();

                var page = new MatchingPage();
                page.Matches.Data = matches;
                return page;
            }, internalOption);
        }
    }
}

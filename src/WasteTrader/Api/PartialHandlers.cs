using Simplified.Ring3;
using Starcounter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;
using WasteTrader.Helpers;
using WasteTrader.ViewModels;

namespace WasteTrader.Api
{
    public class PartialHandlers : IHandler
    {
        public static string PartialPrefix = "/Waste2Value/partial/";
        private static readonly string SELECT_WASTE_BY_ENTRYTIME =
            $"SELECT w FROM {typeof(Waste)} w ORDER BY w.{nameof(Waste.EntryTime)} DESC";

        protected HandlerOptions internalOption = new HandlerOptions { SelfOnly = true };

        public void Register()
        {
            Handle.GET(PartialPrefix + "Hitta", () =>
            {
                var page = new FindPage();
                page.WasteEntries.Data = Db.SQL<Waste>(SELECT_WASTE_BY_ENTRYTIME).Where(w => w.Active);
                return page;
            }, internalOption);

            Handle.GET(PartialPrefix + "drawer", () =>
            {
                return new Drawer() { Authorized = SystemUser.GetCurrentSystemUser() != null };
            }, internalOption);

            Handle.GET(PartialPrefix + "Home", () => new HomePage(), internalOption);

            Handle.GET(PartialPrefix + "header", () => new Header(), internalOption);

            Handle.GET(PartialPrefix + "Registrera", () => new Json(), internalOption);

            Handle.GET(PartialPrefix + "Valkommen", () => new WelcomeMessage(), internalOption);

            Handle.GET(PartialPrefix + "sell", () => new SellPage(), internalOption);

            Handle.GET(PartialPrefix + "user/{?}", (string username) => 
            {
                var page = new UserPage();
                page.Data = Db.SQL<SystemUser>($"SELECT c FROM {typeof(SystemUser)} c WHERE c.{nameof(SystemUser.Username)} = ?", username).FirstOrDefault();
                return page;
            }, internalOption);

            Handle.GET(PartialPrefix + "WastePage/{?}", (string objectId) =>
            {
                Waste waste = Db.FromId<Waste>(objectId);

                return new WastePage() { Data = waste};
            }, internalOption);

            Handle.GET(PartialPrefix + "WasteEntry/{?}", (string objectId) =>
            {
                Waste waste = Db.FromId<Waste>(objectId);

                return new WasteEntry() { Data = waste };
            }, internalOption);
        }
    }
}

using Starcounter;
using System.Linq;
using Simplified.Ring3;
using WasteTrader.Api;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class UserPage : Json, IBound<SystemUser>
    {
        protected override void OnData()
        {
            var waste = Db.SQL<Waste>($"SELECT w FROM {typeof(Waste)} w WHERE w.{nameof(Database.Waste.User)}.{nameof(SystemUser.Key)} = ?", this.Key);

            foreach (var item in waste)
            {
                if (item.Active)
                    this.ActiveWaste.Add(Self.GET(PartialHandlers.partialPrefix + "WasteEntry/" + item.Key));
                else
                    this.InactiveWaste.Add(Self.GET(PartialHandlers.partialPrefix + "WasteEntry/" + item.Key));
            }

            this.WasteToDisplay = this.ActiveWaste;
        }

        public bool NoWaste => this.WasteToDisplay.Count() == 0;
        public string NoWasteMessage
        {
            get
            {
                if (this.WasteToDisplay == this.ActiveWaste)
                    return "Du har inga aktiva annonser just nu";
                else
                    return "Du har inga inaktiva annonser just nu";
            }
        }

        void Handle(Input.OpenActiveTrigger action)
        {
            this.WasteToDisplay = this.ActiveWaste;
        }

        void Handle(Input.OpenInactiveTrigger action)
        {
            this.WasteToDisplay = this.InactiveWaste;
        }
    }
}

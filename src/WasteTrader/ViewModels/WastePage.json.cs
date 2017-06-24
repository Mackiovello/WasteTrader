using Starcounter;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class WastePage : Json, IBound<Waste>
    {
        public string FormattedEntryTime => Data?.EntryTime.Date.ToString("d");

        void Handle(Input.DeleteTrigger action)
        {
            this.RedirectUrl = $"/Waste2Value/user/{this.User.Username}";
            var waste = Db.FromId<Waste>(this.Key);
            Db.Transact(() => waste.Delete());
        }
    }
}

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
            Db.Transact(() => this.Data.Active = false);
        }

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<Client>
        {

        }
    }
}
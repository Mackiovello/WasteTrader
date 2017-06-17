using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class BuyWasteJson : Json, IBound<Database.BuyWaste>
    {
        public string FormattedEntryTime => Data.EntryTime.Date.ToString("d");

        [BuyWasteJson_json.User]
        partial class WasteUser : Json, IBound<Database.Client>
        {

        }
    }
}

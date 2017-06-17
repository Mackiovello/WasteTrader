using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class SellWasteJson : Json, IBound<Database.SellWaste>
    {
        public string FormattedEntryTime => Data.EntryTime.Date.ToString("d");

        [SellWasteJson_json.User]
        partial class WasteUser : Json, IBound<Database.Client>
        {

        }
    }
}

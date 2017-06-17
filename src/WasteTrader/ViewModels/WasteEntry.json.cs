using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class WasteEntry : Json, IBound<Database.SellWaste>
    {
        public string FormattedEntryTime => Data.EntryTime.Date.ToString("d");

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<Database.Client>
        {

        }
    }
}
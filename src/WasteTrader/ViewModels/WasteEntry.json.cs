using Starcounter;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class WasteEntry : Json, IBound<Waste>
    {
        public string FormattedEntryTime => Data?.EntryTime.Date.ToString("d");

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<Client>
        {

        }
    }
}
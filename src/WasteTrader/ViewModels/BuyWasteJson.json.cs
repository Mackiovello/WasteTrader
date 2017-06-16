using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class BuyWasteJson : Json, IBound<Database.BuyWaste>
    {
        public string FormattedEntryTime => Data.EntryTime.Date.ToString("d");
    }
}

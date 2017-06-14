using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class BuyWasteJson : Json, IExplicitBound<Database.BuyWaste>
    {
        public string FormattedEntryTime => Data.EntryTime.Date.ToString("d");
        public string Html => "/WasteTrader/views/WastePage.html";
    }
}

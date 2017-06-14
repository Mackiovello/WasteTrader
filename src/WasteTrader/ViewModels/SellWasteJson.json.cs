using Starcounter;

namespace WasteTrader.ViewModels
{
    partial class SellWasteJson : Json, IExplicitBound<Database.SellWaste>
    {
        public string FormattedEntryTime => Data.EntryTime.Date.ToString("d");
        public string Html => "/WasteTrader/views/WastePage.html";
    }
}

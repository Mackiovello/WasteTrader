using Starcounter;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.ViewModels.Sorters
{
    partial class DateSorterPage : Json
    {
        public static implicit operator DateSorter(DateSorterPage page)
        {
            return new DateSorter(page.DescendingOrder);
        }
    }
}

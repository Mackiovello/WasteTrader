using Starcounter;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.ViewModels.Sorters
{
    partial class PricePerUnitSorterPage : Json
    {
        public static implicit operator PricePerUnitSorter(PricePerUnitSorterPage page)
        {
            return new PricePerUnitSorter(page.DescendingOrder);
        }
    }
}

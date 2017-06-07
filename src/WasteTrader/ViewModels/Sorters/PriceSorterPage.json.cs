using Starcounter;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.ViewModels.Sorters
{
    partial class PriceSorterPage : Json
    {
        public static implicit operator PriceSorter(PriceSorterPage page)
        {
            return new PriceSorter(page.DescendingOrder);
        }
    }
}

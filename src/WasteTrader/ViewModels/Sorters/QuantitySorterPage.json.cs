using Starcounter;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.ViewModels.Sorters
{
    partial class QuantitySorterPage : Json
    {
        public static implicit operator QuantitySorter(QuantitySorterPage page)
        {
            return new QuantitySorter(page.DescendingOrder);
        }
    }
}

using Starcounter;
using WasteTrader.Matchmaking.Sorters;
using WasteTrader.MathUtils;

namespace WasteTrader.ViewModels.Sorters
{
    partial class DistanceSorterPage : Json
    {
        public static implicit operator DistanceSorter(DistanceSorterPage page)
        {
            return new DistanceSorter(page.DescendingOrder, new NoDBLocation((double) page.LongitudeDD, (double) page.LatitudeDD));
        }
    }
}

using Starcounter;
using WasteTrader.Matchmaking.Sorters;
using System.Linq;

namespace WasteTrader.ViewModels.Sorters
{
    partial class WeightedSorterPage : Json
    {
        public static implicit operator WeightedSorter(WeightedSorterPage page)
        {
            var sorters = page.Sorters.AsParallel().ToDictionary(s => (IMatchSorter) s.Sorter, s => (double) s.Weight);
            return new WeightedSorter(page.DescendingOrder, sorters);
        }
    }
}

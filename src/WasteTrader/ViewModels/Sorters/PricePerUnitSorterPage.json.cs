using System.Collections.Generic;
using Starcounter;
using WasteTrader.Database;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.ViewModels.Sorters
{
    partial class PricePerUnitSorterPage : Json, IMatchSorter
    {
        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            PricePerUnitSorter sorter = new PricePerUnitSorter(DescendingOrder);
            return sorter.Sort(waste);
        }

        public string Label => "Dyrast först:";
    }
}

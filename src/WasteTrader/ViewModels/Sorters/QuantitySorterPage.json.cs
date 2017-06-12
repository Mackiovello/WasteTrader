using System.Collections.Generic;
using Starcounter;
using WasteTrader.Database;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.ViewModels.Sorters
{
    partial class QuantitySorterPage : Json, IMatchSorter
    {
        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            QuantitySorter sorter = new QuantitySorter(DescendingOrder);
            return sorter.Sort(waste);
        }
    }
}

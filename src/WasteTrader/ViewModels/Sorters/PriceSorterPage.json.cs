using System;
using System.Collections.Generic;
using Starcounter;
using WasteTrader.Database;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.ViewModels.Sorters
{
    partial class PriceSorterPage : Json, IMatchSorter
    {
        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            PriceSorter sorter = new PriceSorter(DescendingOrder);
            return sorter.Sort(waste);
        }
    }
}

using Starcounter;
using WasteTrader.Matchmaking.Sorters;
using System;
using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.ViewModels.Sorters
{
    partial class DateSorterPage : Json, IMatchSorter
    {
        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            var sorter = new DateSorter(DescendingOrder);
            return sorter.Sort(waste);
        }
    }
}

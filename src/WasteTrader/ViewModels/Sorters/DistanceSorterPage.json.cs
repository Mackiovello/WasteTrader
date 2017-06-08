using System;
using System.Collections.Generic;
using Starcounter;
using WasteTrader.Database;
using WasteTrader.Matchmaking.Sorters;
using WasteTrader.MathUtils;

namespace WasteTrader.ViewModels.Sorters
{
    partial class DistanceSorterPage : Json, IMatchSorter
    {
        static DistanceSorterPage()
        {
            DefaultTemplate.LongitudeDD.InstanceType = typeof(double);
            DefaultTemplate.LatitudeDD.InstanceType = typeof(double);
        }

        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            DistanceSorter sorter = new DistanceSorter(DescendingOrder, new NoDBLocation(LongitudeDD, LatitudeDD));
            return sorter.Sort(waste);
        }
    }
}

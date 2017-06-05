using System;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public class QuantitySorter : IMatchSorter
    {
        protected bool DescendingOrder;
        public QuantitySorter(bool DescendingOrder)
        {
            this.DescendingOrder = DescendingOrder;
        }

        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            var valued = waste.AsParallel().Select(p => new Tuple<Waste, IComparable>(p, p.Measurement.Value));
            return ValueSorter.Sort(valued.AsEnumerable(), DescendingOrder);
        }
    }
}

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
            var valued = waste.AsParallel().Select(p => new Tuple<Waste, long>(p, p.Measurement.Value));
            var sorted = DescendingOrder ? valued.OrderByDescending(p => p.Item2) : valued.OrderBy(p => p.Item2);
            var cleaned = sorted.Select(p => p.Item1).ToArray();
            return cleaned;
        }
    }
}

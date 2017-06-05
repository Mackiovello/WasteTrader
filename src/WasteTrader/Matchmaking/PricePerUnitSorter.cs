using System;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public class PricePerUnitSorter : IMatchSorter
    {
        public bool DescendingOrder;
        public PricePerUnitSorter(bool DescendingOrder)
        {
            this.DescendingOrder = DescendingOrder;
        }
        protected double CalcPPU(Waste waste)
        {
            return ((double)waste.Price) / ((double)waste.Measurement.Value);
        }

        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            var calculatedWaste = waste.AsParallel().Select(p => new Tuple<Waste, double>(p, CalcPPU(p)));
            var sorted = DescendingOrder ? calculatedWaste.OrderByDescending(p => p.Item2) : calculatedWaste.OrderBy(p => p.Item2);
            var cleaned = sorted.Select(p => p.Item1).ToArray();
            return cleaned;
        }
    }
}

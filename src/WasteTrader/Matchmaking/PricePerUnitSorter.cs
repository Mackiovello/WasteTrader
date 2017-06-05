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
            var calculatedWaste = waste.AsParallel().Select(p => new Tuple<Waste, IComparable>(p, CalcPPU(p)));
            return ValueSorter.Sort(calculatedWaste, DescendingOrder);
        }
    }
}

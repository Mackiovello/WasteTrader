using System;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking.Sorters
{
    public class QuantitySorter : GenericSorter
    {
        public QuantitySorter(bool descendingOrder)
        {
            this.DescendingOrder = descendingOrder;
        }

        protected override IComparable Valuer(Waste waste)
        {
            return waste.Measurement.Value;
        }
    }
}

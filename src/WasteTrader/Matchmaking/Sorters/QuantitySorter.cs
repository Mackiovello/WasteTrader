using System;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
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

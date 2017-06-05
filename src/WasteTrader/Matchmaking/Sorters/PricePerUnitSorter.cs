using System;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public class PricePerUnitSorter : GenericSorter
    {
        public PricePerUnitSorter(bool descendingOrder)
        {
            this.DescendingOrder = descendingOrder;
        }

        protected override IComparable Valuer(Waste waste)
        {
            return waste.Price / waste.Measurement.Value;
        }
    }
}

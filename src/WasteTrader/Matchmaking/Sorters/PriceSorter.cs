using System;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking.Sorters
{
    public class PriceSorter : GenericSorter
    {
        public PriceSorter(bool descendingOrder)
        {
            this.DescendingOrder = descendingOrder;
        }

        protected override IComparable Valuer(Waste waste)
        {
            return waste.Price;
        }
    }
}

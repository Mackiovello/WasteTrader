using System;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public class DateSorter : GenericSorter
    {
        public DateSorter(bool descendingOrder)
        {
            this.DescendingOrder = descendingOrder;
        }
        protected override IComparable Valuer(Waste waste)
        {
            return waste.EntryTime;
        }
    }
}

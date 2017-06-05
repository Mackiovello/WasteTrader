using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

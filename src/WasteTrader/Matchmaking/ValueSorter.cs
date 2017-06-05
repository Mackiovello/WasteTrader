using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public static class ValueSorter
    {
        public static Waste[] Sort(IEnumerable<Tuple<Waste,IComparable>> waste, bool DescendingOrder)
        {
            var sorted = DescendingOrder ? waste.OrderByDescending(p => p.Item2) : waste.OrderBy(p => p.Item2);
            var cleaned = sorted.Select(p => p.Item1).ToArray();
            return cleaned;
        }
    }
}

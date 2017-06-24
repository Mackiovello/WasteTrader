using System;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking.Sorters
{
    public abstract class GenericSorter : IMatchSorter
    {
        public bool DescendingOrder { get; protected set; } = false;
        protected abstract IComparable Valuer(Waste waste);

        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            var sorted = DescendingOrder ? 
                waste.OrderByDescending(p => Valuer(p)) :
                waste.OrderBy(p => Valuer(p));

            return sorted.ToArray();
        }
    }
}

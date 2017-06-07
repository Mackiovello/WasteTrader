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
            var valued = waste.AsParallel().Select(p => new Tuple<Waste, IComparable>(p, Valuer(p)));
            var sorted = DescendingOrder ? valued.OrderByDescending(p => p.Item2) : valued.OrderBy(p => p.Item2);
            Waste[] cleaned = sorted.Select(p => p.Item1).ToArray();
            return cleaned;
        }
    }
}

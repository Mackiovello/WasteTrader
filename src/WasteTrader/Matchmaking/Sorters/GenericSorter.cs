using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public abstract class GenericSorter : IMatchSorter
    {
        public bool DescendingOrder { get; protected set; }
        protected abstract IComparable Valuer(Waste waste);

        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            var valued = waste.AsParallel().Select(p => new Tuple<Waste, IComparable>(p, Valuer(p)));
            var sorted = DescendingOrder ? valued.OrderByDescending(p => p.Item2) : valued.OrderBy(p => p.Item2);
            var cleaned = sorted.Select(p => p.Item1).ToArray();
            return cleaned;
        }
    }
}

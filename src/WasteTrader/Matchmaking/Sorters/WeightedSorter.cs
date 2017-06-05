using System;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking.Sorters
{

    public class WeightedSorter : IMatchSorter
    {
        protected IDictionary<IMatchSorter, double> SortersAndWeights;
        protected bool DescendingOrder;

        public WeightedSorter(bool descendingOrder, IDictionary<IMatchSorter, double> sortersAndWeights)
        {
            this.DescendingOrder = descendingOrder;
            this.SortersAndWeights = sortersAndWeights;
        }

        protected IDictionary<Waste, double> getWeights(IMatchSorter sorter, double weight, IEnumerable<Waste> waste)
        {
            Waste[] sorted = sorter.Sort(waste);
            int maxPos = waste.Count() - 1;
            var weighted = sorted.AsParallel().Select((p, i) => new Tuple<Waste, double>(p, (weight * i) / maxPos));
            return weighted.ToDictionary(p => p.Item1, p => p.Item2);
        }

        protected IDictionary<Waste, double> joiner(IDictionary<Waste, double> dic1, IDictionary<Waste, double> dic2)
        {
            var joined = Enumerable.Join(dic1, dic2, pair => pair.Key, pair => pair.Key, (outer, inner) => new KeyValuePair<Waste, double>(outer.Key, outer.Value + inner.Value));
            return joined.ToDictionary(p => p.Key, p => p.Value);
        }

        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            var subSorted = SortersAndWeights.AsParallel().Select(p => getWeights(p.Key, p.Value, waste));
            IDictionary<Waste,double> accumulated = subSorted.Aggregate(joiner);
            var sorted = DescendingOrder ? accumulated.OrderByDescending(p => p.Value) : accumulated.OrderBy(p => p.Value);
            Waste[] cleaned = sorted.Select(p => p.Key).ToArray();
            return cleaned;
        }
    }
}

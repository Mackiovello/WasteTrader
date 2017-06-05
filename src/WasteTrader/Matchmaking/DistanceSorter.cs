using System;
using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;
using WasteTrader.MathUtils;

namespace WasteTrader.Matchmaking
{
    public class DistanceSorter : IMatchSorter
    {
        protected bool DescendingOrder;
        protected Location source;

        public DistanceSorter(bool DescendingOrder, Location source)
        {
            this.DescendingOrder = DescendingOrder;
        }

        protected double CalcDistance(Location location)
        {
            return GeographyMath.RoughEarthDistance(source, location);
        }

        public Waste[] Sort(IEnumerable<Waste> waste)
        {
            var calculated = waste.AsParallel().Select(p => new Tuple<Waste, IComparable>(p, CalcDistance(p.Location)));
            return ValueSorter.Sort(calculated, DescendingOrder);
        }
    }
}

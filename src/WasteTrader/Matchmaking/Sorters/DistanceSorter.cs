using System;
using WasteTrader.Database;
using WasteTrader.MathUtils;

namespace WasteTrader.Matchmaking.Sorters
{
    public class DistanceSorter : GenericSorter
    {
        protected ILocation SourceLocation;
        public DistanceSorter(bool descendingOrder, ILocation sourceLocation)
        {
            this.DescendingOrder = descendingOrder;
            this.SourceLocation = sourceLocation;
        }

        protected override IComparable Valuer(Waste waste)
        {
            return GeographyMath.RoughEarthDistance(SourceLocation, waste.Location);
        }
    }
}

using System;
using WasteTrader.Database;
using WasteTrader.MathUtils;

namespace WasteTrader.Matchmaking
{
    public class DistanceSorter : GenericSorter
    {
        protected Location SourceLocation;
        public DistanceSorter(bool descendingOrder, Location sourceLocation)
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

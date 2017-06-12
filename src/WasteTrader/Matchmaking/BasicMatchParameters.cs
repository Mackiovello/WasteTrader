using System;
using WasteTrader.Database;
using WasteTrader.Matchmaking.Sorters;
using WasteTrader.MathUtils;

namespace WasteTrader.Matchmaking
{
    public class BasicMatchParameters : IMatchParameters
    {
        public double MaxDistance { get; set; }

        public double MinDistance { get; set; }

        public int MaxMatches { get; set; }

        public double PricePerUnitLimit { get; set; }

        public long MaxQuantity { get; set; }

        public long MinQuantity { get; set; }

        public DateTime? Oldest { get; set; }

        public DateTime Youngest { get; set; }

        public UnitType UnitType { get; set; }

        public ILocation SearchFrom { get; set; }

        public IMatchSorter Sorter { get; set; }
    }
}

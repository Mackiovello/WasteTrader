using System;
using Starcounter;
using WasteTrader.Database;
using WasteTrader.Matchmaking;
using WasteTrader.Matchmaking.Sorters;
using WasteTrader.MathUtils;

namespace WasteTrader.ViewModels
{
    partial class MatchParametersPage : Json, IMatchParameters
    {
        static MatchParametersPage()
        {
            DefaultTemplate.Parameters.MaxDistance.Bind = "MaxDistance";
            DefaultTemplate.Parameters.MinDistance.Bind = "MinDistance";
            DefaultTemplate.Parameters.MaxMatches.Bind = "MaxMatches";
            DefaultTemplate.Parameters.PricePerUnitLimit.Bind = "PricePerUnitLimit";
            DefaultTemplate.Parameters.MaxQuantity.Bind = "MaxQuantity";
            DefaultTemplate.Parameters.MinQuantity.Bind = "MinQuantity";
            DefaultTemplate.Parameters.Oldest.Bind = "Oldest";
            DefaultTemplate.Parameters.Youngest.Bind = "Youngest";
            DefaultTemplate.Parameters.UnitType.Bind = "UnitType";
        }

        public double MaxDistance { get; }

        public double MinDistance { get; }

        public int MaxMatches { get; }

        public double PricePerUnitLimit { get; }

        public long MaxQuantity { get; }

        public long MinQuantity { get; }

        public DateTime Oldest { get; }

        public DateTime Youngest { get; }

        public UnitType UnitType { get; }

        public ILocation SearchFrom => new NoDBLocation((double) Parameters.LongitudeDD, (double) Parameters.LatitudeDD);

        public IMatchSorter Sorter => throw new NotImplementedException();
    }
}

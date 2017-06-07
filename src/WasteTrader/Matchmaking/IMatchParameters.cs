using System;
using WasteTrader.Database;
using WasteTrader.MathUtils;
using WasteTrader.Matchmaking.Sorters;

namespace WasteTrader.Matchmaking
{
    public interface IMatchParameters
    {
        /// <summary>
        /// Lenght in meters to search in. 0 is infinite.
        /// </summary>
        double MaxDistance { get; }
        /// <summary>
        /// Minimum distance in meters that should be allowed.
        /// </summary>
        double MinDistance { get; }
        /// <summary>
        /// Number of matches to make, a limiter.
        /// </summary>
        int MaxMatches { get; }
        /// <summary>
        /// The highest price per unit that should be allowed. 0 allows everything.
        /// </summary>
        double PricePerUnitLimit { get; }
        /// <summary>
        /// The highest quantity that should be allowed.
        /// </summary>
        long MaxQuantity { get; }
        /// <summary>
        /// The lowest quantity that should be allowed.
        /// </summary>
        long MinQuantity { get; }
        /// <summary>
        /// Oldest allowed post date, null is infinite.
        /// </summary>
        DateTime Oldest { get; }
        /// <summary>
        /// Youngest allowed post date
        /// </summary>
        DateTime Youngest { get; }
        /// <summary>
        /// Unit type filter. 0 is allow all.
        /// </summary>
        UnitType UnitType { get; }
        /// <summary>
        /// The location to calculate distance from.
        /// </summary>
        ILocation SearchFrom { get; }
        /// <summary>
        /// The class that sorts the matches.
        /// </summary>
        IMatchSorter Sorter { get; }
    }
}

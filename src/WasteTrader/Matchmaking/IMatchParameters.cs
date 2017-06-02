using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using WasteTrader.Database;

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
        int Matches { get; }
        /// <summary>
        /// The highest price per unit that should be allowed. 0 allows everything.
        /// </summary>
        decimal PricePerUnitLimit { get; }
        /// <summary>
        /// The highest quantity that should be allowed.
        /// </summary>
        BigInteger MaxQuantity { get; }
        /// <summary>
        /// The lowest quantity that should be allowed.
        /// </summary>
        BigInteger MinQuantity { get; }
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
        byte UnitType { get; }
        /// <summary>
        /// The location to calculate distance from.
        /// </summary>
        Location SearchFrom { get; }
        /// <summary>
        /// The class that sorts the matches.
        /// </summary>
        IMatchSorter Sorter { get; }
    }
}

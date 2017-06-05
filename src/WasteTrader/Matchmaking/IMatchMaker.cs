using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public interface IMatchMaker
    {
        /// <summary>
        /// Searches for BuyWaste based on parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Matched BuyWaste</returns>
        BuyWaste[] MatchSeller(IMatchParameters parameters);
        /// <summary>
        /// Searches for SellWaste based on parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Matched SellWaste</returns>
        SellWaste[] MatchBuyer(IMatchParameters parameters);
        /// <summary>
        /// Searches through a set of IWaste based on parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="searchspace"></param>
        /// <returns>Matched IWaste</returns>
        Waste[] Match(IMatchParameters parameters, IEnumerable<Waste> searchspace);
    }
}

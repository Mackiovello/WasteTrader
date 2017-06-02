using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public interface IMatchMaker
    {
        BuyWaste[] MatchSeller(IMatchParameters parameters);
        SellWaste[] MatchBuyer(IMatchParameters parameters);
        IWaste[] Match(IMatchParameters parameters, IEnumerable<IWaste> searchspace);
    }
}

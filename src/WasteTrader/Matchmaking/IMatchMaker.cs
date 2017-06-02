using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public interface IMatchMaker
    {
        ImmutableArray<BuyWaste> MatchSeller(IMatchParameters parameters);
        ImmutableArray<SellWaste> MatchBuyer(IMatchParameters parameters);
        ImmutableArray<IWaste> Match(IMatchParameters parameters, IImmutableSet<IWaste> searchspace);
    }
}

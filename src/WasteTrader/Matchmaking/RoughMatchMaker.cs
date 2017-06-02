using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using WasteTrader.Database;
using Starcounter;

namespace WasteTrader.Matchmaking
{
    public abstract class RoughMatchMaker : IMatchMaker
    {
        public BuyWaste[] MatchSeller(IMatchParameters parameters)
        {
            var ss = Db.SQL<IWaste>("SELECT i FROM WasteTrader.BuyWaste i WHERE i.Category = ?", parameters.UnitType).ToImmutableSortedSet();
            var refined = Match(parameters, ss).Cast<BuyWaste>().ToArray();
            return refined;
        }
        public SellWaste[] MatchBuyer(IMatchParameters parameters)
        {
            var ss = Db.SQL<IWaste>("SELECT i FROM WasteTrader.SellWaste i WHERE i.Category = ?", parameters.UnitType).ToImmutableSortedSet();
            var refined = Match(parameters, ss).Cast<SellWaste>().ToArray();
            return refined;
        }
        public abstract IWaste[] Match(IMatchParameters parameters, IEnumerable<IWaste> searchspace);
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.Database;
using Starcounter;

namespace WasteTrader.Matchmaking
{
    public abstract class RoughMatchMaker : IMatchMaker
    {
        public ImmutableArray<BuyWaste> MatchSeller(IMatchParameters parameters)
        {
            var ss = Db.SQL<IWaste>("SELECT i FROM WasteTrader.BuyWaste i WHERE i.Category = ?", parameters.UnitType).ToImmutableSortedSet();
            var refined = Match(parameters, ss).Cast<BuyWaste>().ToImmutableArray();
            return refined;
        }
        public ImmutableArray<SellWaste> MatchBuyer(IMatchParameters parameters)
        {
            var ss = Db.SQL<IWaste>("SELECT i FROM WasteTrader.SellWaste i WHERE i.Category = ?", parameters.UnitType).ToImmutableSortedSet();
            var refined = Match(parameters, ss).Cast<SellWaste>().ToImmutableArray();
            return refined;
        }
        public abstract ImmutableArray<IWaste> Match(IMatchParameters parameters, IImmutableSet<IWaste> searchspace);
    }
}

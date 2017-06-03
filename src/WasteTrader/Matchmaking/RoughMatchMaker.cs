using System.Collections.Generic;
using System.Linq;
using WasteTrader.Database;
using Starcounter;

namespace WasteTrader.Matchmaking
{
    public abstract class RoughMatchMaker : IMatchMaker
    {
        public BuyWaste[] MatchSeller(IMatchParameters parameters)
        {
            var result = Db.SQL<Waste>("SELECT i FROM WasteTrader.BuyWaste i WHERE i.Category = ?", parameters.UnitType);
            BuyWaste[] refined = Match(parameters, result).Cast<BuyWaste>().ToArray();
            return refined;
        }
        public SellWaste[] MatchBuyer(IMatchParameters parameters)
        {
            var result = Db.SQL<Waste>("SELECT i FROM WasteTrader.SellWaste i WHERE i.Category = ?", parameters.UnitType);
            SellWaste[] refined = Match(parameters, result).Cast<SellWaste>().ToArray();
            return refined;
        }
        public abstract Waste[] Match(IMatchParameters parameters, IEnumerable<Waste> searchspace);
    }
}

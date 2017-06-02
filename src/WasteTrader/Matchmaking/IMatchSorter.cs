using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public interface IMatchSorter
    {
        IWaste[] Sort(IEnumerable<IWaste> waste);
    }
}

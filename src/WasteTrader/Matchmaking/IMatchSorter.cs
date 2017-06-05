using System.Collections.Generic;
using WasteTrader.Database;

namespace WasteTrader.Matchmaking
{
    public interface IMatchSorter
    {
        Waste[] Sort(IEnumerable<Waste> waste);
    }
}
